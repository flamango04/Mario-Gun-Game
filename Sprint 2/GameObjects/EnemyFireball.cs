using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;


namespace Sprint_2.GameObjects
{
    public class EnemyFireball : Interfaces.IUpdateable, Interfaces.IDrawable, ICollideable
    {
        private ISprite fireball;
        private float xPos;
        private float yPos;

        public EnemyFireball(Vector2 location)
        {
            xPos = location.X;
            yPos = location.Y;

            fireball = UniversalSpriteFactory.Instance.MarioFireball();
        }

        public void Update(GameTime gameTime)
        {
            fireball.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            fireball.Draw(spriteBatch, new Vector2(xPos, yPos), color);
        }

        public int GetColumn()
        {
            return (int)(xPos / CollisionConstants.blockWidth);
        }

        public string GetCollisionType()
        {
            return "EnemyProjectile";
        }
        public Rectangle GetHitBox()
        {
            return fireball.GetHitBox(new Vector2(xPos, yPos));
        }
        public void SetPosition(Vector2 position)
        {
            xPos = position.X;
            yPos = position.Y;
        }
        public Vector2 GetPosition()
        {
            return new Vector2(xPos, yPos);
        }
    }
}
