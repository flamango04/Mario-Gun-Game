using Sprint_2.Interfaces;
using Sprint_2.Sprites;

namespace Sprint_2.Commands.MarioMovementCommands
{
    public class MarioFacingUpCommand : ICommands
    {
        private IPlayer mario;

        public MarioFacingUpCommand(IPlayer player)
        {
            mario = player;
        }

        public void Execute()
        {
            if (mario.isCrouching)
            {
                mario.ReleaseCrouch();
            }
            mario.Jump();
        }
    }
}
