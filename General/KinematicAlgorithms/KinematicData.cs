using Stride.Core.Mathematics;

namespace Zin.General.KinematicAlgorithms
{
    // Describes the character's position and current motion.
    public class KinematicData
    {
        public Vector3 Position { get; set; }
        public float Orientation { get; set; }
        public Vector3 Velocity { get; set; }
        public float Rotation { get; set; }
    }
}
