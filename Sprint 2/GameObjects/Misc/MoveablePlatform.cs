using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Misc
{
    public class MoveablePlatform : Interfaces.IUpdateable, Interfaces.IDrawable, ICollideable
    {
        private ISprite sprite;

        private float XPos;
        private float YPos;
        private float leftMostXPos;
        private float rightMostXPos;
        private float speed = MiscConstants.movingPlatformSpeed;

        public MoveablePlatform(Vector2 location, float range)
        {
            XPos = location.X;
            YPos = location.Y;
            leftMostXPos = XPos - range;
            rightMostXPos = XPos + range;

            sprite = UniversalSpriteFactory.Instance.GetBlock(nameof(MoveablePlatform));
        }

        public void Update(GameTime gameTime)
        {
            MovePlatform();
            sprite.Update(gameTime);
        }
        private void MovePlatform()
         {
            XPos += speed;
            if (XPos == leftMostXPos || XPos == rightMostXPos)
            {
                speed *= -1;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }
        public float GetSpeed()
        {
            return speed;
        }
        public string GetCollisionType()
        {
            return nameof(MoveablePlatform);
        }
        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }
        public int GetColumn()
        {
            return (int)(XPos / CollisionConstants.blockWidth);
        }
    }
}
