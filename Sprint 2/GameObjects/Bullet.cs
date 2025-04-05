using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Commands.CollisionCommands;
using Sprint_2.Sound;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.MarioStates;
using Sprint_2.Sprites;
using System;
using System.Diagnostics;

namespace Sprint_2.GameObjects
{
    public class Bullet : Interfaces.IUpdateable, Interfaces.IDrawable, ICollideable
    {
        private ISprite bulletSprite;
        private Vector2 location;
        private Vector2 velocity = new Vector2(4, 0);
        private Vector2 direction;
        private Vector2 origin;
        private float rotation;
        private PlayerStateMachine.Facing facing;

        public Bullet(float rotation, Vector2 location, PlayerStateMachine.Facing facing)
        {
            this.rotation = rotation;
            this.location = location;
            this.facing = facing;
            
            if (facing == PlayerStateMachine.Facing.Left)
            {
                velocity *= -1;
            }

            float cos = (float)Math.Cos(rotation);
            float sin = (float)Math.Sin(rotation);
            velocity = new Vector2(velocity.X * cos - velocity.Y * sin, velocity.X * sin + velocity.Y * cos);
            bulletSprite = UniversalSpriteFactory.Instance.GetBulletSprite();
        }

        public void Update(GameTime gameTime)
        {
            location += velocity;
            
            if (location.Y < MiscConstants.levelBounds.Y || location.Y > MiscConstants.despawnHeight)
            {
                Delete();
            }
            bulletSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            bulletSprite.Draw(spriteBatch, location, color, rotation, Vector2.Zero, SpriteEffects.None);
        }

        public Rectangle GetHitBox()
        {
            Rectangle hitBox = bulletSprite.GetHitBox(location);
            //Need to make hitbox smaller because the hitbox can not be rotated
            Rectangle adjustedHitBox;
            if (Math.Floor(velocity.X) <= 0 && facing == PlayerStateMachine.Facing.Left)
            {
                adjustedHitBox = new Rectangle(hitBox.X - (hitBox.Width / 2), hitBox.Y + (hitBox.Height / 2), hitBox.Width / 2, hitBox.Height);
            }
            else
            {
                adjustedHitBox = new Rectangle(hitBox.X + (hitBox.Width / 2), hitBox.Y + (hitBox.Height / 2), hitBox.Width / 2, hitBox.Height);
            }
            
            return adjustedHitBox;
        }

        public string GetCollisionType()
        {
            return nameof(Bullet);
        }
        public int GetColumn()
        {
            return (int)location.X / CollisionConstants.blockWidth;
        }

        public void Delete()
        {
            SoundManager.Instance.PlaySoundEffect("stomp");

            GameObjectManager.Instance.ForeDrawables.Remove(this);
            GameObjectManager.Instance.Movers.Remove(this);
            GameObjectManager.Instance.Updateables.Remove(this);
        }
    }
}
