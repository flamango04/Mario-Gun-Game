using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioMovementCommands
{
    public class MarioOnCrouchRelease : ICommands
    {
        private IPlayer mario;

        public MarioOnCrouchRelease(IPlayer mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            if (!mario.isJumping)
            {
                mario.ReleaseCrouch();
                //mario.Idle();
            }
            
        }
    }
}
