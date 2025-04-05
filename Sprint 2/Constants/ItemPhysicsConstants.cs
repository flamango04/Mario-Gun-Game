using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Constants
{
    public static class ItemPhysicsConstants
    {
        public static float maxFallVelocity = 300f;
        public static Vector2 fallVelocity = new Vector2(0, 8);
        public static float bounceVelocity = -200f;
        public static float coinHeightIncrease = 40;

        public const int coinHeightChange = -2;
        public const float defaultMoveSpeed = 1;
    }
}
