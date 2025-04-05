using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.GameObjects.Enemies.EnemyStates;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sprites;
using System.Diagnostics;

namespace Sprint_2.GameObjects.Enemies.EnemySprites
{
    public class BulletBill : ICollideable, Interfaces.IUpdateable, Interfaces.IDrawable
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public enum Direction {Left, Right }
        public bool Flipped { get; set; }
        private BulletStateMachine bulletState;
        public Vector2 Velocity { get; set; }

        private int index = 0;
        public BulletBill(Vector2 initialPosition, Direction direction)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;
            Velocity = new Vector2(0, EnemyConstants.fallVelocity.Y);
            bulletState = new BulletStateMachine(this, direction);
        }


        public void Update(GameTime gameTime)
        {
            if (XPos < Game1.Instance.GetCamera().GetLeftScreenBound().X)
            {
                GameObjectManager.Instance.RemoveMover(this);
            }
            bulletState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            bulletState.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        public Rectangle GetHitBox()
        {
            return bulletState.GetHitBox(new Vector2(XPos, YPos));
        }

        public void TakeStompDamage()
        {
            Flipped = true;
            Velocity = EnemyConstants.flippedVelocity;
            bulletState.BeFlipped();
            GameObjectManager.Instance.Movers.Remove(this);
        }

        public string GetCollisionType()
        {
            return "MovingBullet";
        }
        public void Move()
        {
            bulletState.Move();
        }

        public int GetColumn()
        {
            return (int)(XPos / CollisionConstants.blockWidth);
        }
    }
}
