using Stride.Core.Mathematics;

namespace Zin.General.KinematicAlgorithms
{
    public class SteeringOutput
    {
        public Vector3 Linear { get; set; }
        public float Angular { get; set; }
    }

    public class KinematicSteeringOutput
    {
        public Vector3 Velocity { get; set; }
        public float Rotation { get; set; }
    }
}
