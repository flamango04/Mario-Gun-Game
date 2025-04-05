using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_2.Interfaces
{
    public interface ISprite
    {
        //Vector2 Position { get; set; }
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, Vector2 vector2, Color color);

        public void Draw(SpriteBatch spriteBatch, Vector2 vector2, Color color, float rotation, Vector2 origin, SpriteEffects effect);


        public Rectangle GetHitBox(Vector2 location);

    }
}
