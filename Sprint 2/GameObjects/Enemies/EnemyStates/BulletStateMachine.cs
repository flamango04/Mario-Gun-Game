using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Collision;
using Sprint_2.Commands.MarioMovementCommands;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sprites.EnemySprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public class BulletStateMachine
    {
        private BulletBill bullet;
        private ISprite sprite;
        private enum BulletHealth {Normal, Flipped};
        BulletHealth health = BulletHealth.Normal;
        private IBulletBehavior bulletBehavior;

        private bool movingLeft = true;
        private bool startBehavior = false;

        public BulletStateMachine(BulletBill bullet, BulletBill.Direction direction)
        {
            this.bullet = bullet;
            if (direction == BulletBill.Direction.Left)
            {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.LeftBullet.ToString());
            } else
            {
                movingLeft = false;
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.RightBullet.ToString());
            }
        }

        public void Update(GameTime gameTime)
        {
            if (!bullet.Flipped)
            {
                Move();
            }
            else if (bullet.Flipped)
            {
                bulletBehavior.Update(gameTime);
            }

            sprite.Update(gameTime);
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            sprite.Draw(spriteBatch, location, color);
        }

        public void BeFlipped()
        {

            if (health != BulletHealth.Flipped)
            {
                health = BulletHealth.Flipped;
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.FlippedBullet.ToString());

                bulletBehavior = new BulletFlippedState(bullet);
            }
        }

        public void Move()
        {
            if (movingLeft)
            {
                bullet.Velocity = new Vector2(-EnemyConstants.moveSpeed, 0);
            }
            else
            {
                bullet.Velocity = new Vector2(EnemyConstants.moveSpeed, 0);
            }
            bullet.XPos += bullet.Velocity.X;
        }

        public Rectangle GetHitBox(Vector2 location)
        {
            return sprite.GetHitBox(location);
        }
    }
}
