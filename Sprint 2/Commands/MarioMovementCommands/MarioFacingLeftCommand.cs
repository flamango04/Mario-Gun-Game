using Sprint_2.Sprites;
using Sprint_2.Interfaces;

namespace Sprint_2.Commands.MarioMovementCommands
{
    public class MarioFacingLeftCommand : ICommands
    {
        private IPlayer mario;

        public MarioFacingLeftCommand(IPlayer player)
        {
            mario = player;
        }

        public void Execute()
        {
            mario.MoveLeft();
        }
    }
}
