using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.Sprites.EnemySprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public class GoombaStateMachine
    {
        private bool facingLeft = true;
        private enum GoombaHealth { Normal, Stomped, Flipped};
        private GoombaHealth health = GoombaHealth.Normal;


        private Goomba goomba;
        private ISprite sprite;
        private IGoombaBehavior goombaBehavior;

        public GoombaStateMachine(Goomba goomba)
        {
            this.goomba = goomba;

            goombaBehavior = new GoombaBehaviorMoving(goomba);
            sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.Goomba.ToString());
        }
        public void ChangeDirection()
        {
            if (health == GoombaHealth.Normal)
            {
                facingLeft = !facingLeft;
            }
        }

        public void BeStomped()
        {
            if (health != GoombaHealth.Stomped)
            {
                health = GoombaHealth.Stomped;
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.StompedGoomba.ToString());
                goombaBehavior = new GoombaBehaviorStomped(goomba);
                goomba.YPos += goomba.GetHitBox().Height;
            }
        }

        public void BeFlipped()
        {
            if (health != GoombaHealth.Flipped)
            {
                health = GoombaHealth.Flipped;
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.FlippedGoomba.ToString());

                goombaBehavior = new GoombaBehaviorFlipped(goomba);
            }
        }

        public void Move()
        {
            if (facingLeft)
            {
                goomba.Velocity = new Vector2(-EnemyConstants.moveSpeed, goomba.Velocity.Y);
            }
            else
            {
                goomba.Velocity = new Vector2(EnemyConstants.moveSpeed, goomba.Velocity.Y);
            }
            goomba.XPos += goomba.Velocity.X;
        }

        public void Update(GameTime gameTime)
        {
            goombaBehavior.Update(gameTime);
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            sprite.Draw(spriteBatch, location, color);
        }

        public Rectangle GetHitBox(Vector2 location)
        {
            return sprite.GetHitBox(location);
        }
    }
}
