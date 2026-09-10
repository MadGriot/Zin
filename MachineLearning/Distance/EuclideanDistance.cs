using MathNet.Numerics.LinearAlgebra;

namespace Zin.MachineLearning.Distance
{
    public sealed class EuclideanDistance : IDistanceMetric
    {
        public Matrix<double> Calculate(Matrix<double> query, Matrix<double> reference)
        {
            /*
             * query:     Q x D
             * reference: N x D
             * result:    Q x N
             *
             * ||q - r||² =
             *     ||q||² + ||r||² - 2(q · r)
             */

            Vector<double> querySquaredNorms = query.PointwisePower(2).RowSums();
            Vector<double> referenceSquaredNorms = reference.PointwisePower(2).RowSums();
            Matrix<double> distancesSquared = query * reference.Transpose() * -2.0;

            // Broadcast query squared norms across columns.
            distancesSquared += Matrix<double>.Build.Dense(query.RowCount, reference.RowCount,
                                            (i, _) => querySquaredNorms[i]);

            // Broadcast reference squared norms across rows.
            distancesSquared += Matrix<double>.Build.Dense(query.RowCount, reference.RowCount,
                                        (_, j) => referenceSquaredNorms[j]);

            // Protect against tiny negative floating-point errors.
            distancesSquared = distancesSquared.PointwiseMaximum(0.0);

            return distancesSquared.PointwiseSqrt();
        }
    }
}
