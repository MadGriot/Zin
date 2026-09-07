using Stride.Core.Mathematics;

namespace Zin.General.KinematicAlgorithms
{
    public class Kinematic
    {
        public Vector3 Position { get; set; }
        public float Orientation { get; set; }
        public Vector3 Velocity { get; set; }
        public float Rotation { get; set; }

        public void Update(SteeringOutput steering, float time)
        {
            float halfTimeSquared = 0.5f * time * time;

            Position += Velocity * time + steering.Linear * halfTimeSquared;
            Orientation += Rotation * time + steering.Angular * halfTimeSquared;

            Velocity += steering.Linear * time;
            Rotation += steering.Angular * time;
        }
    }
}
