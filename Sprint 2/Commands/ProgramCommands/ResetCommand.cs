using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.ProgramCommands
{
    public class ResetCommand : ICommands
    {
        private Game1 myGame;

        public ResetCommand()
        {
            myGame = Game1.Instance;
        }

        public void Execute()
        {
            myGame.Reload();
        }
    }
}
