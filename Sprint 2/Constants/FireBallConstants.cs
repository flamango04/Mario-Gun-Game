using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Constants
{
    public class FireBallConstants
    {
        public static int scale = 1;
        
        public static Vector2 moveSpeed = new Vector2(0.05f,0); 

        public static float XSpeed = 200f;
        public static float maxFallSpeed = 300f;
        public static Vector2 fallSpeed = new Vector2(0, 10);

        public static float bounceSpeed = -150f;

        public static float animationDelay = 0.1f;
        public static int explosionRange = 350;

        public const float timeToFinishExplosion = 0.3f;

    }
}
