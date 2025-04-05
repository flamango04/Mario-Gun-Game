using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint_2.Constants;
using Sprint_2.GameStates;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.MarioPhysicsStates;
using Sprint_2.Sound;

namespace Sprint_2.MarioStates
{
    public class HealthState
    {
        public enum HealthEnum { Dead, Mario, SuperMario, FireMario };
        public HealthEnum health { get; private set; }

        private IPlayer mario;

        public HealthState(IPlayer mario)
        {
            health = HealthEnum.Mario;
            this.mario = mario;
        }


        public void PowerUp()
        {
            if (health != HealthEnum.Dead && health != HealthEnum.FireMario)
            {
                if (health.Equals(HealthEnum.Mario))
                {
                    mario.YPos -= mario.GetHitBox().Height;
                }
                health++; 
            }
        }
        public void Damage()
        {
            if (health == HealthEnum.Mario)
            {
                health = HealthEnum.Dead;

                SoundManager.Instance.StopBackgroundMusic();
                SoundManager.Instance.PlayBackgroundMusic("youAreDead");

                mario.PhysicsState = new DeadMario(mario);
                mario.PlayerVelocity = new Vector2(0, MarioPhysicsConstants.bounceVelocity);
                GameObjectManager.Instance.Movers.Remove(mario);
               
                mario.RemainingLives--;
            }
            else
            {
                /* All damage sets Fire/Super mario to little mario */

                if (mario.isCrouching)
                {
                    mario.Idle();
                }
                health = HealthEnum.Mario;

                SoundManager.Instance.PlaySoundEffect("pipe");

                mario.YPos += mario.GetHitBox().Height;

            }
        }

        public string GetHealth()
        {
            return health.ToString();
        }
    }
}
