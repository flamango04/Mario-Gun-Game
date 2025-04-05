using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;

namespace Sprint_2.GameObjects
{
    public class StaticSprite : IStaticSprite
    {
        private Texture2D texture;
        private Rectangle[] sourceRectangles;
        public Vector2 Position { get; set; } 
        public StaticSprite(Texture2D texture, Rectangle[] sourceRectangles, Vector2 position)
        {
            this.texture = texture;
            this.sourceRectangles = sourceRectangles;
            this.Position = position;  
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(texture, Position, sourceRectangles[0], color);
        }
    }
}