using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.ProgramCommands
{
    public class TotalResetCommand : ICommands
    {
        public TotalResetCommand()
        {

        }

        public void Execute()
        {
            Game1.Instance.TotalReset();
        }
    }
}
