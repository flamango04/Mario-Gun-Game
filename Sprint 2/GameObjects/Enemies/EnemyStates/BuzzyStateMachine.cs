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
    public class BuzzyStateMachine
    {
        private Buzzy buzzy;
        private ISprite sprite;

        private bool facingLeft = true;
        private enum Health { Normal, Shell, Flipped};
        private Health health = Health.Normal;

        private bool startBehavior = false;

        public BuzzyStateMachine(Buzzy buzzy)
        {
            this.buzzy = buzzy;

            /* Assume buzzy starts facing left*/
            sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.LeftFacingBuzzy.ToString());
        }

        public void ChangeDirection()
        {

            facingLeft = !facingLeft;
            if (facingLeft)
            {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.LeftFacingBuzzy.ToString());
            }
            else
            {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.RightFacingBuzzy.ToString());
            }
        }

        public void Update(GameTime gameTime)
        {
            startBehavior = UpdateStartBehavior();
            if (startBehavior)
            {
                /* Apply Gravity*/
                if (buzzy.Velocity.Y < EnemyConstants.maxFallVelocity)
                {
                    buzzy.Velocity += EnemyConstants.fallVelocity;
                }

                if (health == Health.Normal)
                {
                    Move();
                }

                /* Move Position*/
                buzzy.YPos += (float)(buzzy.Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
                buzzy.Velocity = new Vector2(buzzy.Velocity.X, buzzy.Velocity.Y * MarioPhysicsConstants.velocityDecay);

                /* if the buzzy falls out of the map */
                if (buzzy.YPos > MiscConstants.despawnHeight)
                {
                    GameObjectManager.Instance.Movers.Remove(buzzy);
                    GameObjectManager.Instance.Updateables.Remove(buzzy);
                    GameObjectManager.Instance.BackDrawables.Remove(buzzy);
                }

            }
            sprite.Update(gameTime);
        }
        private bool UpdateStartBehavior()
        {
            float distToPlayer = Math.Abs(Game1.Instance.mario.XPos - buzzy.XPos);
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
                buzzy.Velocity = new Vector2(-EnemyConstants.moveSpeed, buzzy.Velocity.Y);
            }
            else
            {
                buzzy.Velocity = new Vector2(EnemyConstants.moveSpeed, buzzy.Velocity.Y);
            }
            buzzy.XPos += buzzy.Velocity.X;
        }

        public void BeStomped()
        {
            if (health != Health.Shell)
            {
                health = Health.Shell;
                int bottomPos = buzzy.GetHitBox().Bottom;
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.BuzzyShell.ToString());
                bottomPos -= sprite.GetHitBox(new Vector2(buzzy.XPos, buzzy.YPos)).Height; 

                GameObjectManager.Instance.Movers.Remove(buzzy);
                GameObjectManager.Instance.Updateables.Remove(buzzy);
                GameObjectManager.Instance.BackDrawables.Remove(buzzy);

                Shell shell = new Shell(new Vector2(buzzy.XPos, bottomPos), "Buzzy");
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
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.FlippedBuzzyShell.ToString());
                buzzy.Velocity = EnemyConstants.flippedVelocity;
            }
        }
        public Rectangle GetHitBox(Vector2 location)
        {
            return sprite.GetHitBox(location);
        }
    }
}
