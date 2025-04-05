using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Factories;
using Sprint_2.GameObjects.Enemies.EnemyStates;
using System.Threading;
using System.Linq.Expressions;
using Sprint_2.Constants;
using System.Diagnostics;
using System;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.LevelManager;

namespace Sprint_2.GameObjects.Enemies
{
    public class LavaBubble : IEnemy
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public bool Flipped { get; set; }
        public Vector2 Velocity { get; set; }
        private ISprite sprite;
        public LavabubbleStateMachine LavaState { get; set; }
        public LavaBubble(Vector2 initialPosition, int maxHeight)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;

            LavaState = new LavabubbleStateMachine(this, maxHeight);
            Velocity = new Vector2(0, EnemyConstants.lavaBubbleYSpeed);
        }


        public void Update(GameTime gameTime)
        {
            LavaState.Update(gameTime, YPos);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            LavaState.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        public Rectangle GetHitBox()
        {
            return LavaState.GetHitBox(new Vector2(XPos, YPos));
        }


        public void TakeFireballDamage()
        {
        }

        public void TakeStompDamage()
        {
        }

        public void ChangeDirection()
        {
        }

        public string GetCollisionType()
        {
            return nameof(LavaBubble);
        }

        public int GetColumn()
        {
            return (int)(XPos / CollisionConstants.blockWidth);
        }
    }
}

