using Sprint_2.Interfaces;
using Sprint_2.MarioPhysicsStates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Sprint_2.MarioStates
{
    public class PoseState
    {
        public enum PoseEnum { Idle, Run, Jump, Crouch, Fall, Slide, Shoot, Climb }
        public PoseEnum pose { get; private set; }
        private IPlayer mario;

        public PoseState(IPlayer mario)
        {
            this.mario = mario;
            /* Assume Player starts at idle */
            pose = PoseEnum.Idle;
        }
        public void Shoot()
        {
            if (pose != PoseEnum.Crouch)
            {
                pose = PoseEnum.Shoot;
            }
        }
        public void Slide()
        {
            if (pose == PoseEnum.Run)
            {
                pose = PoseEnum.Slide;
            }
        }
        public void Jump()
        {
            if (pose != PoseEnum.Fall)
            {
                pose = PoseEnum.Jump;
            }
            else if (pose == PoseEnum.Crouch)
            {
                pose = PoseEnum.Idle;
            }
        }

        public void Run()
        {
            if (pose == PoseEnum.Idle || pose == PoseEnum.Slide)
            {
                pose = PoseEnum.Run;
            }
        }

        public void Crouch()
        {
            if (pose != PoseEnum.Jump && pose != PoseEnum.Fall)
            {
                mario.isCrouching = true;
                int bottomPositionOfSprite = mario.GetHitBox().Bottom;
                pose = PoseEnum.Crouch;
                mario.YPos = bottomPositionOfSprite - mario.GetHitBox().Height;
            }
        }
        public void Idle()
        {
            if (pose != PoseEnum.Jump)
            {
                pose = PoseEnum.Idle;
            }
        }

        public void Fall()
        {
            pose = PoseEnum.Fall;
        }

        public void Climb()
        {
            pose = PoseEnum.Climb;
        }

        public string GetPose()
        {
            return pose.ToString();
        }
    }
}
