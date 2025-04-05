using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.GameObjects;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.MarioStates;
using System.Timers;

namespace Sprint_2.MarioPhysicsStates
{
    internal class EndOfDemoPhysicsState : IMarioPhysicsStates
    {
        private IPlayer mario;
        private Timer moveRightTimer;
        private Timer stopMovingTimer;
        public EndOfDemoPhysicsState()
        {
            mario = Game1.Instance.mario;
            
            if (mario.GetFacing().Equals(PlayerStateMachine.Facing.Left))
            {
                mario.MoveRight();
            }

            moveRightTimer = new Timer(MarioPhysicsConstants.timeBetweenMovementForAnimations);
            moveRightTimer.AutoReset = true;
            moveRightTimer.Enabled = true;
            moveRightTimer.Elapsed += (s, e) => MoveRightElapsedEvent(s, e, mario);

            stopMovingTimer = new Timer(MarioPhysicsConstants.timeToWalkToEndScreen);
            stopMovingTimer.AutoReset = false;
            stopMovingTimer.Enabled = true;
            stopMovingTimer.Elapsed += (s, e) => StopMovingElapsedEvent(s, e, moveRightTimer);
        }

        public void Update(GameTime gameTime)
        {
            mario.PhysicsState = new Grounded(mario);
        }

        private static void MoveRightElapsedEvent(object s, ElapsedEventArgs e, IPlayer mario) 
        {
            mario.MoveRight();
        }
        private static void StopMovingElapsedEvent(object s, ElapsedEventArgs e, Timer moveRightTimer)
        {
            moveRightTimer.Dispose();
        }

    }
}
