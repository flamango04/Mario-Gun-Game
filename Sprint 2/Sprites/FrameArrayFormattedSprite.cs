using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;


namespace Sprint_2.Sprites
{
    public class FrameArrayFormattedSprite : ISprite
    {
        private Texture2D texture;
        private float animationSpeed;
        private float initialAnimationSpeed;

        private Rectangle[] frames;
        private int currentFrame = 0;

        private Vector2 size;
        private float scale;

        public FrameArrayFormattedSprite(Texture2D texture, Rectangle[] frames, float scale)
        {
            this.texture = texture;
            this.frames = frames;
            this.scale = scale;

            size = new Vector2(frames[currentFrame].Width, frames[currentFrame].Height);
            size *= scale;

            animationSpeed = MiscConstants.animationSpeed;
            initialAnimationSpeed = animationSpeed;
        }

        public void Update(GameTime gameTime)
        {
            float timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
            animationSpeed -= timer;

            if (animationSpeed <= 0)
            {
                currentFrame++;
                currentFrame %= frames.Length;

                size = new Vector2(frames[currentFrame].Width, frames[currentFrame].Height);
                size *= scale;

                animationSpeed = initialAnimationSpeed;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y);
            spriteBatch.Draw(texture, destinationRectangle, frames[currentFrame], color);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color, float rotation, Vector2 origin, SpriteEffects effect)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y);
            spriteBatch.Draw(texture, destinationRectangle, frames[currentFrame], color, rotation, origin, effect, 0);
        }

        public Rectangle GetHitBox(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y);
        }
    }
}
