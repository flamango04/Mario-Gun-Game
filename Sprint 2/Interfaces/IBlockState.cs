using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint_2.Interfaces
{
    public interface IBlockState
    {
        void BeHit(IPlayer player);

        Rectangle GetHitBox(Vector2 location);

        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);

        void Update(GameTime gameTime);
    }
}
