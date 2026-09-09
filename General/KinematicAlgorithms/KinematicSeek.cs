using Stride.Core.Mathematics;

namespace Zin.General.KinematicAlgorithms
{
    public class KinematicSeek
    {
        public Static Character { get; set; } = null!;
        public Static Target { get; set; } = null!;
        public float MaxSpeed;

        public KinematicSteeringOutput GetSteering()
        {
            KinematicSteeringOutput result = new();

            result.Velocity = Target.Position - Character.Position;

            result.Velocity.Normalize();
            result.Velocity *= MaxSpeed;

            Character.Orientation = NewOrientation(Character.Orientation, result.Velocity);
            result.Rotation = 0f;

            return result;
        }

        //Quaternions go here??
        public float NewOrientation(float orientation, Vector3 velocity)
        {
            return 0f;
        }
    }
}
