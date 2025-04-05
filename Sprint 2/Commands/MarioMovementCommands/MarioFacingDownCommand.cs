using Sprint_2.Interfaces;
using Sprint_2.Sprites;

namespace Sprint_2.Commands.MarioMovementCommands
{
    public class MarioFacingDownCommand : ICommands
    {
        private IPlayer mario;

        public MarioFacingDownCommand(IPlayer player)
        {
            mario = player;
        }

        public void Execute()
        {
            mario.Crouch();
        }
    }
}
