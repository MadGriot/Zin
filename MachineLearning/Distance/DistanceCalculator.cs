using MathNet.Numerics.LinearAlgebra;

namespace Zin.MachineLearning.Distance
{
    public class DistanceCalculator(IDistanceMetric metric)
    {
        private readonly IDistanceMetric metric = metric ?? throw new ArgumentNullException(nameof(metric));


        public Matrix<double> Calculate(Matrix<double> query, Matrix<double> reference)
        {
            ValidateDimensions(query, reference);
            return metric.Calculate(query, reference);
        }

        private static void ValidateDimensions(Matrix<double> query, Matrix<double> reference)
        {
            if (query is null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (reference is null)
            {
                throw new ArgumentNullException(nameof(reference));
            }

            if (query.RowCount == 0)
            {
                throw new ArgumentException(
                    "Query data cannot be empty.",
                    nameof(query));
            }

            if (reference.RowCount == 0)
            {
                throw new ArgumentException(
                    "Reference data cannot be empty.",
                    nameof(reference));
            }

            if (query.ColumnCount != reference.ColumnCount)
            {
                throw new ArgumentException(
                    "Query and reference data must have " +
                    "the same number of features.");
            }
        }
    }


}
