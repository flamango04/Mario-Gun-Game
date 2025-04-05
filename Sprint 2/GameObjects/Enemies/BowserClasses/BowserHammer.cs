using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.BowserClasses
{
    public class BowserHammer : Interfaces.IUpdateable, Interfaces.IDrawable, ICollideable
    {
        private ISprite sprite;
        private Vector2 velocity;
        private float XPos;
        private float YPos;


        public BowserHammer(Vector2 location, bool facingLeft)
        {
            XPos = location.X;
            YPos = location.Y;

            sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.BowserHammer.ToString());
            velocity = EnemyConstants.hammerVelocity;
            if (!facingLeft)
            {
                velocity *= new Vector2(-1, 1);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (velocity.Y < EnemyConstants.maxFallVelocity)
            {
                velocity += EnemyConstants.fallVelocity;
            }

            if (YPos > MiscConstants.despawnHeight)
            {
                DeleteHammer();
            }

            XPos += (float)(velocity.X * gameTime.ElapsedGameTime.TotalSeconds);
            YPos += (float)(velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);

            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }
        public string GetCollisionType()
        {
            return "EnemyProjectile";
        }
        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }
        public int GetColumn()
        {
            return (int)XPos / CollisionConstants.blockWidth;
        }
        public void DeleteHammer()
        {
            GameObjectManager.Instance.Updateables.Remove(this);
            GameObjectManager.Instance.BackDrawables.Remove(this);
            GameObjectManager.Instance.Movers.Remove(this);
        }
    }
}
