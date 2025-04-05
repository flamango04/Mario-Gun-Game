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
    public class Koopa : IEnemy
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public bool Flipped { get; set; } = false;
        public Vector2 Velocity { get; set; }

        private KoopaStateMachine koopaState;

        public Koopa(Vector2 initialPosition)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;
            Velocity = new Vector2(-EnemyConstants.moveSpeed, 0); // Moving left by default

            koopaState = new KoopaStateMachine(this);
        }

        public void Update(GameTime gameTime)
        {
            koopaState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            koopaState.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        public Rectangle GetHitBox()
        {
            return koopaState.GetHitBox(new Vector2(XPos, YPos));
        }

        public void TakeFireballDamage()
        {
            Flipped = true;
            koopaState.BeFlipped();
            GameObjectManager.Instance.Movers.Remove(this);
        }

        public void TakeStompDamage()
        {
            koopaState.BeStomped();
        }
        public void ChangeDirection()
        {
            koopaState.ChangeDirection();
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
