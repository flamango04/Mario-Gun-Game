using Sprint_2.Interfaces;
using Sprint_2.MarioPhysicsStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioMovementCommands
{
    public class MarioJumpReleaseCommand : ICommands
    {
        private IPlayer player;

        public MarioJumpReleaseCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute() 
        {
            
            if (!player.isFalling && player.PhysicsState is not Grounded)
            {
                if (player.isJumping)
                {
                    player.Fall();
                }
               
            }
            
        }
    }
}
