using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.ProgramCommands
{
    public class QuitCommand : ICommands
    {

        public QuitCommand()
        {
        }

        public void Execute()
        {
            Game1.Instance.Exit();
        }
    }
}
