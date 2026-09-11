using MathNet.Numerics.LinearAlgebra;
using Zin.MachineLearning.Distance;

namespace Zin.MachineLearning.Classification
{
    public sealed class KNNClassifier(int k = 3, DistanceMetric metric = DistanceMetric.Euclidean)
    {
        private readonly int k = k;
        private readonly DistanceMetric metric = metric;

        private Matrix<double>? xTrain;
        private int[]? yTrain;

        public KNNClassifier Fit(Matrix<double> X, IEnumerable<int> y)
        {
            if (X is null)
            {
                throw new ArgumentNullException(nameof(X));
            }

            if (y is null)
            {
                throw new ArgumentNullException(nameof(y));
            }

            int[] labels = y.ToArray();
            if (X.RowCount == 0)
            {
                throw new ArgumentException(
                    "Training data cannot be empty.",
                    nameof(X));
            }

            if (labels.Length != X.RowCount)
            {
                throw new ArgumentException(
                    "The number of labels must match the number of training rows.",
                    nameof(y));
            }

            if (k <= 0)
            {
                throw new ArgumentException(
                    "k must be greater than zero.",
                    nameof(k));
            }

            if (k > X.RowCount)
            {
                throw new ArgumentException(
                    "k cannot be greater than the number of training samples.",
                    nameof(k));
            }
            // Store copies so the classifier owns its training data.
            xTrain = X.Clone();
            yTrain = (int[])labels.Clone();

            return this;
        }

        public int[] Predict(Matrix<double> X)
        {
            if (X is null)
            {
                throw new ArgumentNullException(nameof(X));
            }

            if (xTrain is null || yTrain is null)
            {
                throw new InvalidOperationException(
                    "The classifier must be fitted before calling Predict.");
            }

            if (X.ColumnCount != xTrain.ColumnCount)
            {
                throw new ArgumentException(
                    "Query data must have the same number of features " +
                    "as the training data.",
                    nameof(X));
            }

            /*
             * Calculate the COMPLETE distance matrix in one call.
             *
             * distances[i, j] =
             *     distance(X[i], xTrain[j])
             *
             * Shape:
             *     query rows x training rows
             */
            DistanceCalculator calculator = DistanceCalculatorFactory.Create(metric);
            Matrix<double> distances = calculator.Calculate(X, xTrain);
            int[] predictions = new int[X.RowCount];

            for (int i = 0; i < X.RowCount; i++)
            {
                predictions[i] = PredictRow(distances.Row(i));
            }
            return predictions;

        }

        private int PredictRow(Vector<double> distances)
        {
            /*
             * Select the k nearest training samples.
             *
             * Order by:
             *   1. distance
             *   2. training index
             *
             * The second ordering makes selection deterministic when
             * two training samples have exactly the same distance.
             */
            int[] nearest = Enumerable
                .Range(0, distances.Count)
                .OrderBy(index => distances[index])
                .ThenBy(index => index)
                .Take(k)
                .ToArray();
                        /*
             * Group the k neighbors by class.
             *
             * For each class we calculate:
             *   - vote count
             *   - mean distance
             */
            var classStatistics = nearest
                .GroupBy(index => yTrain![index])
                .Select(group => new ClassStatistics
                {
                    Label = group.Key,
                    VoteCount = group.Count(),
                    MeanDistance = group.Average(
                        index => distances[index])
                });
            /*
             * Deterministic tie handling:
             *
             * 1. Most votes wins.
             * 2. If vote count ties, smallest mean neighbor distance wins.
             * 3. If that also ties, smallest class label wins.
             */
            return classStatistics
                .OrderByDescending(x => x.VoteCount)
                .ThenBy(x => x.MeanDistance)
                .ThenBy(x => x.Label)
                .First()
                .Label;
        }
        private sealed class ClassStatistics
        {
            public int Label { get; init; }

            public int VoteCount { get; init; }

            public double MeanDistance { get; init; }
        }
    }
}
