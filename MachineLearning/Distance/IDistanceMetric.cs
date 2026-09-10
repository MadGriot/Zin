using MathNet.Numerics.LinearAlgebra;

namespace Zin.MachineLearning.Distance
{
    public interface IDistanceMetric
    {
        Matrix<double> Calculate(Matrix<double> query, Matrix<double> reference);
    }
}
