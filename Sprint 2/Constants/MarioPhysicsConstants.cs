using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Constants
{
    public class MarioPhysicsConstants
    {
        public static Vector2 marioXVelocity = new Vector2(8f, 0);
        //Jump Velocity is negative because y=0 is at the top of the screen
        public static Vector2 marioJumpVelocity = new Vector2(0, -10f);
        public static Vector2 marioFallVelocity = new Vector2(0, 9f);

        public static float velocityDecay = 0.965f;

        public static float maxXVelocity = 450f;
        public static float maxJumpVelocity = -300f;
        public static float maxFallVelocity = 300f;

        public static int maxJumpHeight = 64;

        public static float gravity = 57f;

        public static float fallRange = gravity * 1.25f;

        public static float flashSpeed = 0.075f;
        public static float damagedTime = 3f;

        public static float bounceVelocity = -250f;

        public static int startingLives = 3;

        public static Vector2 velocityJumpingOffFlagPole = new Vector2(100, 0);

        public static int timeBetweenMovementForAnimations = 50; /* units : milliseconds */
        public static int timeToReachCastle = 1500; /* units : milliseconds */

        public static int starDuration = 750;
        public static int timeBetweenColorsScaleFactor = 4;

        public static float maxSlideVelocity = 50f;
        public static int maxNumOfFireballs = 2;

        public static int heightOfCrouch = 22;

        public static int minTransitionToFallState = -5;
        public static float initialJumpVelocity = -50;

        public const string startingMarioState = "RightMarioIdle";

        public readonly static int[] marioBounceScores = new int[] { 100, 200, 400, 500, 800, 1000, 2000, 4000, 5000, 8000 };

        public const int timeToWalkToEndScreen = 4000;
    }
}
