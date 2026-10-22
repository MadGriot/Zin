using Stride.Core.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zin.General.KinematicAlgorithms
{
    public static class KinematicSeekBehavior
    {
        public static KinematicSteeringOutput GetSteering(KinematicData character, Vector3 targetPosition,
            float maxSpeed)
        {
            Vector3 direction = targetPosition - character.Position;

            // Constrain movement to the XZ ground plane.
            direction.Y = 0f;

            if (direction.LengthSquared() > 0.0001f)
            {
                direction.Normalize();
                direction *= maxSpeed;
            }
            else
            {
                direction = Vector3.Zero;
            }

            return new KinematicSteeringOutput
            {
                Velocity = direction,
                Rotation = 0f
            };
        }
    }
}
