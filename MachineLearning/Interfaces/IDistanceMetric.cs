using MathNet.Numerics.LinearAlgebra;

namespace Zin.MachineLearning.Interfaces
{
    public interface IDistanceMetric
    {
        Matrix<double> Calculate(Matrix<double> query, Matrix<double> reference);
    }
}
