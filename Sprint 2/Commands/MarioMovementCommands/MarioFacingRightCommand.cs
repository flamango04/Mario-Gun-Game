using Sprint_2.Interfaces;
using Sprint_2.Sprites;


namespace Sprint_2.Commands.MarioMovementCommands

{
    public class MarioFacingRightCommand : ICommands
    {
        private IPlayer mario;

        public MarioFacingRightCommand(IPlayer player)
        {
            mario = player;
        }

        public void Execute()
        {
            mario.MoveRight();
        }
    }
}


