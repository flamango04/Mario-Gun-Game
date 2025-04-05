using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Collision;
using Sprint_2.Commands.MarioMovementCommands;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public class KoopaStateMachine
    {
        private Koopa koopa;
        private ISprite sprite;

        private bool facingLeft = true;
        private enum Health { Normal, Shell, Flipped};
        private Health health = Health.Normal;

        private bool startBehavior = false;

        public KoopaStateMachine(Koopa koopa)
        {
            this.koopa = koopa;

            /* Assume Koopa starts facing left*/
            sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.LeftFacingKoopa.ToString());
        }

        public void ChangeDirection()
        {

            facingLeft = !facingLeft;
            if (facingLeft)
            {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.LeftFacingKoopa.ToString());
            }
            else
            {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.RightFacingKoopa.ToString());
            }
        }

        public void Update(GameTime gameTime)
        {
            startBehavior = UpdateStartBehavior();
            if (startBehavior)
            {
                /* Apply Gravity*/
                if (koopa.Velocity.Y < EnemyConstants.maxFallVelocity)
                {
                    koopa.Velocity += EnemyConstants.fallVelocity;
                }

                if (health == Health.Normal)
                {
                    Move();
                }

                /* Move Position*/
                koopa.YPos += (float)(koopa.Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
                koopa.Velocity = new Vector2(koopa.Velocity.X, koopa.Velocity.Y * MarioPhysicsConstants.velocityDecay);

                /* if the koopa falls out of the map */
                if (koopa.YPos > MiscConstants.despawnHeight)
                {
                    GameObjectManager.Instance.Movers.Remove(koopa);
                    GameObjectManager.Instance.Updateables.Remove(koopa);
                    GameObjectManager.Instance.BackDrawables.Remove(koopa);
                }

            }
            sprite.Update(gameTime);
        }
        private bool UpdateStartBehavior()
        {
            float distToPlayer = Math.Abs(Game1.Instance.mario.XPos - koopa.XPos);
            if (distToPlayer < EnemyConstants.distUntilBehaviorStarts)
            {
                startBehavior = true;
            }
            return startBehavior;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            sprite.Draw(spriteBatch, location, color);
        }

        public void Move()
        {
            if (facingLeft)
            {
                koopa.Velocity = new Vector2(-EnemyConstants.moveSpeed, koopa.Velocity.Y);
            }
            else
            {
                koopa.Velocity = new Vector2(EnemyConstants.moveSpeed, koopa.Velocity.Y);
            }
            koopa.XPos += koopa.Velocity.X;
        }

        public void BeStomped()
        {
            if (health != Health.Shell)
            {
                health = Health.Shell;
                int bottomPos = koopa.GetHitBox().Bottom;
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.KoopaShell.ToString());
                bottomPos -= sprite.GetHitBox(new Vector2(koopa.XPos, koopa.YPos)).Height; 

                GameObjectManager.Instance.Movers.Remove(koopa);
                GameObjectManager.Instance.Updateables.Remove(koopa);
                GameObjectManager.Instance.BackDrawables.Remove(koopa);

                Shell shell = new Shell(new Vector2(koopa.XPos, bottomPos), "Koopa");
                GameObjectManager.Instance.Movers.Add(shell);
                GameObjectManager.Instance.Updateables.Add(shell);
                GameObjectManager.Instance.BackDrawables.Add(shell);
                
            }
        }

        public void BeFlipped()
        {
            if (health != Health.Flipped)
            {
                health = Health.Flipped;
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.FlippedKoopaShell.ToString());
                koopa.Velocity = EnemyConstants.flippedVelocity;
            }
        }
        public Rectangle GetHitBox(Vector2 location)
        {
            return sprite.GetHitBox(location);
        }
    }
}
