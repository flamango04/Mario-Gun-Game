using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Misc
{
    public class Axe : Interfaces.IUpdateable, Interfaces.IDrawable, ICollideable
    {
        private float xPos;
        private float yPos;
        private ISprite sprite;

        public Axe(Vector2 position)
        {
            xPos = position.X;
            yPos = position.Y;

            sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.Axe.ToString());
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(xPos, yPos), color);
        }

        public Rectangle GetHitBox()
        {
            Rectangle hitBox = sprite.GetHitBox(new Vector2(xPos, yPos));
            float scaleFactor = MiscConstants.axeHitBoxScaleFactor;
            /*Makes Hitbox smaller so mario can only collide with the axe when he will land on the block 
             underneath the axe */
            Rectangle adjustedHitBox = new Rectangle(hitBox.X + (int)(CollisionConstants.blockWidth / scaleFactor), (int)yPos, hitBox.Width - 
                (int)(CollisionConstants.blockWidth / scaleFactor), hitBox.Height);
            return adjustedHitBox;
        }
        public int GetColumn()
        {
            return (int)(xPos / CollisionConstants.blockWidth);
        }
        public string GetCollisionType()
        {
            return nameof(Axe);
        }
    }
}
