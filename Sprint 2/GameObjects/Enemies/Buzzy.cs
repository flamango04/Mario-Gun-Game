using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.GameObjects.Enemies.EnemyStates;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Linq.Expressions;


namespace Sprint_2.GameObjects.Enemies.EnemySprites
{
    public class Buzzy : IEnemy
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public bool Flipped { get; set; } = false;
        public Vector2 Velocity { get; set; }

        private BuzzyStateMachine BuzzyState;

        public Buzzy(Vector2 initialPosition)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;
            Velocity = new Vector2(-EnemyConstants.moveSpeed, 0); // Moving left by default

            BuzzyState = new BuzzyStateMachine(this);
        }

        public void Update(GameTime gameTime)
        {
            BuzzyState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            BuzzyState.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        public Rectangle GetHitBox()
        {
            return BuzzyState.GetHitBox(new Vector2(XPos, YPos));
        }

        public void TakeFireballDamage()
        {
        }

        public void TakeStompDamage()
        {
            BuzzyState.BeStomped();
        }
        public void ChangeDirection()
        {
            BuzzyState.ChangeDirection();
        }

        public string GetCollisionType()
        {
            return typeof(IEnemy).Name;
        }

        public int GetColumn()
        {
            return (int)(XPos / CollisionConstants.blockWidth);
        }
    }
}
