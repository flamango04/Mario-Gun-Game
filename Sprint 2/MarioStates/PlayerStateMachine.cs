using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.Constants;
using Sprint_2.GameObjects;
using Sprint_2.MarioPhysicsStates;
using Sprint_2.LevelManager;
using System.Timers;
using System.Diagnostics;

namespace Sprint_2.MarioStates
{
    public class PlayerStateMachine
    {
        private HealthState healthState;
        private ISprite currentSprite;
        private PoseState poseState;
        public enum Facing { Left, Right };
        private Facing facing;

        private IPlayer mario;
        private string key;
        private ISprite oldSprite;

        private float damagedTime = MarioPhysicsConstants.damagedTime;
        private float flashSpeed = MarioPhysicsConstants.flashSpeed;
        private int opacity = 1;
        public PlayerStateMachine(IPlayer mario)
        {
            this.mario = mario;

            healthState = new HealthState(mario);
            poseState = new PoseState(mario);
            facing = Facing.Right;
            
            key = MarioPhysicsConstants.startingMarioState;
            currentSprite = UniversalSpriteFactory.Instance.GetMarioSprite(key);
        }

        public void Update(GameTime gameTime)
        {
            oldSprite = currentSprite;
            ChangeSprite();
            UpdateFlashingTime(gameTime);
            currentSprite.Update(gameTime);
            
        }

        private void UpdateFlashingTime(GameTime gameTime)
        {
            if (mario.IsDamaged)
            {
                damagedTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                flashSpeed -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (flashSpeed < 0)
                {
                    opacity = (++opacity) % 2;
                    flashSpeed = MarioPhysicsConstants.flashSpeed;
                }
                if (damagedTime < 0)
                {
                    damagedTime = MarioPhysicsConstants.damagedTime;
                    mario.IsDamaged = false;
                }

            }
        }
        public void Die()
        {
            currentSprite = UniversalSpriteFactory.Instance.GetDeadMarioSprite();

            mario.PlayerVelocity = new Vector2(0, MarioPhysicsConstants.bounceVelocity);
            GameObjectManager.Instance.Movers.Remove(mario);

            mario.PhysicsState = new DeadMario(mario);

            mario.RemainingLives--;
        }
        public void PowerUp()
        {
            healthState.PowerUp();
        }
        public void Damage()
        {
            if (!healthState.health.Equals(HealthState.HealthEnum.Dead))
            {
                if (poseState.pose.Equals(PoseState.PoseEnum.Shoot))
                {
                    Idle();
                }
                healthState.Damage();
                /* May want to rework so it doesn't check if mario is dead twice */
                if (!healthState.health.Equals(HealthState.HealthEnum.Dead))
                {
                    mario.IsDamaged = true;
                }
            }
            
        }
        public void Jump()
        {
            poseState.Jump();
        }
        public void Fall()
        {
            poseState.Fall();
        }

        public void Crouch()
        {
            if (!healthState.health.Equals(HealthState.HealthEnum.Mario))
            {
                poseState.Crouch();
            }
        }

        public void MoveLeft()
        {
            if (poseState.pose.Equals(PoseState.PoseEnum.Jump) || poseState.pose.Equals(PoseState.PoseEnum.Fall))
            {
                if (mario.PlayerVelocity.X > -MarioPhysicsConstants.maxXVelocity)
                {
                    mario.PlayerVelocity -= MarioPhysicsConstants.marioXVelocity;
                }
            }
            else if (!poseState.pose.Equals(PoseState.PoseEnum.Crouch) && !healthState.health.Equals(HealthState.HealthEnum.Dead))
            {

                facing = Facing.Left;

                if (mario.PlayerVelocity.X > -MarioPhysicsConstants.maxXVelocity)
                {
                    mario.PlayerVelocity -= MarioPhysicsConstants.marioXVelocity;
                }

                if (mario.PlayerVelocity.X > MarioPhysicsConstants.maxSlideVelocity)
                {
                    poseState.Slide();
                }
                else
                {
                    poseState.Run();
                }
                
            }

        }
        public void MoveRight()
        {
            
            if (poseState.pose.Equals(PoseState.PoseEnum.Jump) || poseState.pose.Equals(PoseState.PoseEnum.Fall))
            {

                if (mario.PlayerVelocity.X < MarioPhysicsConstants.maxXVelocity)
                {
                    mario.PlayerVelocity += MarioPhysicsConstants.marioXVelocity;
                }
            }
            else if (!poseState.pose.Equals(PoseState.PoseEnum.Crouch) && !healthState.health.Equals(HealthState.HealthEnum.Dead))
            {
                facing = Facing.Right;
                if (mario.PlayerVelocity.X < MarioPhysicsConstants.maxXVelocity)
                {
                    mario.PlayerVelocity += MarioPhysicsConstants.marioXVelocity;
                }

                if (mario.PlayerVelocity.X < MarioPhysicsConstants.maxSlideVelocity)
                {
                    poseState.Slide();
                }
                else
                {
                    poseState.Run();
                }
                
            }
        }
        public void Idle()
        {
            poseState.Idle();
        }
        public void Climb()
        {
            poseState.Climb();
        }

        public FireBall ShootFireball()
        {
            FireBall fireball = null;
            if (healthState.health.Equals(HealthState.HealthEnum.FireMario) && !poseState.pose.Equals(PoseState.PoseEnum.Crouch))
            {

                if (facing.Equals(Facing.Left))
                {
                    fireball = new FireBall(mario, new Vector2(-FireBallConstants.XSpeed, FireBallConstants.fallSpeed.Y));

                }
                else
                {
                    fireball = new FireBall(mario, new Vector2(FireBallConstants.XSpeed, FireBallConstants.fallSpeed.Y));
                }
                poseState.Shoot();
            }
            return fireball;
        }
        public void Draw(SpriteBatch spritebatch, Color color)
        {
            
            if (key.Contains(PoseState.PoseEnum.Shoot.ToString()))
            {
                currentSprite.Draw(spritebatch, new Vector2(mario.XPos, mario.YPos), color * opacity);
                currentSprite = oldSprite;
            }
            else
            {
                currentSprite.Draw(spritebatch, new Vector2(mario.XPos, mario.YPos), color * opacity);
            }


        }

        public void ChangeSprite()
        {
            string newKey = facing.ToString() + healthState.GetHealth() + poseState.GetPose();

            if (healthState.health.Equals(HealthState.HealthEnum.Dead))
            {
                key = newKey;
                currentSprite = UniversalSpriteFactory.Instance.GetDeadMarioSprite();
            }
            else if (!key.Equals(newKey))
            {
                key = newKey;
                currentSprite = UniversalSpriteFactory.Instance.GetMarioSprite(key);
                
            }
        }

        public Rectangle GetHitBox(Vector2 location)
        {
            ChangeSprite();
            return currentSprite.GetHitBox(location);
        }

        public string GetHealth()
        {
            return healthState.GetHealth();
        }

        public Facing GetFacing()
        {
            return facing;
        }
    }
}
