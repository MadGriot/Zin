using MathNet.Numerics.LinearAlgebra;

namespace Zin.MachineLearning.Distance
{
    public sealed class ManhattanDistance : IDistanceMetric
    {
        public Matrix<double> Calculate(Matrix<double> query, Matrix<double> reference)
        {
            int qCount = query.RowCount;
            int rCount = reference.RowCount;

            return Matrix<double>.Build.Dense(
                query.RowCount,
                reference.RowCount,
                (i, j) =>
                    query.Row(i)
                        .Subtract(reference.Row(j))
                        .PointwiseAbs()
                        .Sum());
        }
    }
}
