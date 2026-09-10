namespace Zin.MachineLearning.Distance
{
    public enum DistanceMetric
    {
        Euclidean,
        Manhattan
    }
    public static class DistanceCalculatorFactory
    {
        public static DistanceCalculator Create(DistanceMetric metric)
        {
            return metric switch
            {
                DistanceMetric.Euclidean => new DistanceCalculator(new EuclideanDistance()),

                DistanceMetric.Manhattan => new DistanceCalculator(new ManhattanDistance()),

                _ => throw new ArgumentException("Unknown distance metric.", nameof(metric)),
            };
        }
    }
}
