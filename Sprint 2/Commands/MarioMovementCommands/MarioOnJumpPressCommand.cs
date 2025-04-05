using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioMovementCommands
{
    public class MarioOnJumpPressCommand : ICommands
    {
        private IPlayer player;

        public MarioOnJumpPressCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            if (!player.isJumping && !player.isFalling)
            {
                if (player.isCrouching)
                {
                    player.ReleaseCrouch();
                }
                player.PlayerVelocity = new Vector2(player.PlayerVelocity.X, MarioPhysicsConstants.initialJumpVelocity);
                player.Jump();
            }
            
        }
    }
}
