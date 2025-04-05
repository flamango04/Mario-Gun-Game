using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Sprint_2.GameObjects.ItemSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Constants
{
    public class EnemyConstants
    {
        public static float moveSpeed = 1f;
        public static float maxFallVelocity = 300f;
        public static Vector2 fallVelocity = new Vector2(0, 9);
        public static Vector2 flippedVelocity = new Vector2(0, -150f);

        public static float despawnHeight = 650;

        public static float shellMoveSpeed = 150f;

        public static float distUntilBehaviorStarts = 300;

        public static float timeUntilShellBecomesAlive = 5f;

        public static float stompTimer = 0.75f;

        public static int pointsFromFireball = 200;
        public static int pointsFromStarMario = 100;
        public static int kickShellPoints = 400;

        public static readonly int[] shellScoreValues = new int[] { 500, 800, 1000, 2000, 4000, 5000, 8000 };
        public const int initialBowserHealth = 10;
        public const int bowserXMoveSpeed = -20;

        public const int minBowserFireballSpeed = 50;
        public const int maxBowserFireballSpeed = 100;

        public static readonly Vector2 hammerVelocity = new Vector2(-100, -200);
        public static readonly Vector2 bowserFallVelocity = (fallVelocity / 1.3f);
        public const int lavaBubbleYSpeed = -150;
    }
}
