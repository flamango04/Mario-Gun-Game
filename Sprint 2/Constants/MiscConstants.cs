using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Sprint_2.Constants
{
    public static class MiscConstants
    {
        public static float cameraSmoothingFactor = 0.1f;

        public static Vector2 leftBorderSize = new Vector2(16, 240);
        public static Vector2 leftBorderPosition = new Vector2(0, 240);
        public static float cameraViewPortWidthScale = 8f;
        public static Matrix cameraScale = Matrix.CreateScale(2f, 2f, 1f);

        public static Dictionary<(int, int), int> flagPoints = new Dictionary<(int, int), int>() 
        {
            {(1, 26), 4000 },
            {(26, 71), 2000 },
            {(71, 94), 800 },
            {(94, 133), 400 },
            {(134, 150), 100 }
        };
        public static int maxFlagScore = 5000;
        public static Vector2 levelBounds = new Vector2(3744, 240);

        public static int powerUpPoints = 1000;
        public static int coinPoints = 200;

        public const int blockHeightChange = -2;
        public const int blockTotalHeightChange = 6;

        public const int brokenBlockXVelocity = 50;
        public const int brokenBlockTopYVelocity = 150;
        public const int brokenBlockBottomYVelocity = 50;
        public const int despawnHeight = 464;

        public const float coinCenteringFactor = 2.5f;

        public const int bottomOfFlagPole = 416;

        public const int defaultNumberOfCoins = 6;

        public const int defaultLevelTime = 400;
        public const int hudSpacingBetweenElements = 75;
        public const int hudSpacingForScreen = 50;
        public const float lifetimeOfPoints = 1.5f;
        public const int heightChangeForPopupPoints = 20;

        public const float animationSpeed = 0.1f;

        public readonly static Vector2 scoreTextLocation = new Vector2(150, 390);
        public readonly static Vector2 resetTextLocation = new Vector2(50, 440);
        public readonly static Vector2 quitTextLocation = new Vector2(250, 440);
        public readonly static Vector2 endingTextLocation = new Vector2(150, 340);

        public const float movingPlatformSpeed = -0.5f;
        public readonly static Vector2 sizeOfLevel2 = new Vector2(3336, 240);
        public readonly static Vector2 bossLevelSize = new Vector2(3060, 240);
        public const float axeHitBoxScaleFactor = 3f;
        public const int bottomOfScreen = 480;

        public readonly static Vector2 sizeOfLevel3 = new Vector2(2840, 240);
    }
}
