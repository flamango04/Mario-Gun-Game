using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;


namespace Sprint_2.GameObjects
{
    public class Collider : ICollideable, Interfaces.IDrawable
    {
        private Rectangle collider;
        public Vector2 location { get; set; }
        private string type;
        private Vector2 size;
        public Collider(Vector2 location, Vector2 size, string type)
        {
            this.location = location;
            this.size = size;
            collider = new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y);
            this.type = type;
            
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            collider = new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y);
        }
        public string GetCollisionType()
        {
            return type;
        }

        public Rectangle GetHitBox()
        {
            return new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y);
        }

        public int GetColumn()
        {
            return (int)location.X / CollisionConstants.blockWidth;
        }
    }
}
