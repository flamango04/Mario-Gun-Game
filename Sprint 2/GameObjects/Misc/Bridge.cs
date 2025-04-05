using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Misc
{
    public class Bridge : Interfaces.IDrawable, Interfaces.IUpdateable, ICollideable
    {
        private float xPos;
        private float yPos;

        private ISprite sprite;

        public Bridge(Vector2 location)
        {
            xPos = location.X;
            yPos = location.Y;

            sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.Bridge.ToString());
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(xPos, yPos), color);
        }
        public int GetColumn()
        {
            return (int)(xPos / CollisionConstants.blockWidth);
        }
        public string GetCollisionType()
        {
            return nameof(IBlock);
        }
        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(xPos, yPos));
        }

        public void DeleteBridge()
        {
            GameObjectManager.Instance.RemoveStatic(this);
        }
    }
}
