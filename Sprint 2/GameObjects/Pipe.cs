using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects
{
    public class Pipe : IPipe, ICollideable
    {
        private float XPos;
        private float YPos;

        private ISprite sprite;
        private string pipeSize;

        public Pipe(Vector2 location, string pipeSize)
        {
            XPos = location.X;
            YPos = location.Y;
            this.pipeSize = pipeSize;
            sprite = UniversalSpriteFactory.Instance.GetBlock(pipeSize);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }

        public string GetCollisionType()
        {
            if (pipeSize.Equals(NamesOfSprites.SpriteNames.UndergroundPipe.ToString()))
            {
                return pipeSize;
            }
            return typeof(IBlock).Name;
        }

        public int GetColumn()
        {
            return (int)(XPos / CollisionConstants.blockWidth);
        }
    }
}
