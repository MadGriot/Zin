using Stride.Core.Mathematics;

namespace Zin.General.KinematicAlgorithms
{
    // Used later for dynamic steering behaviors.
    public class SteeringOutput
    {
        public Vector3 Linear { get; set; }
        public float Angular { get; set; }
    }
    // Describes the desired velocity and angular velocity.
    public class KinematicSteeringOutput
    {
        public Vector3 Velocity { get; set; }
        public float Rotation { get; set; }
    }
}
