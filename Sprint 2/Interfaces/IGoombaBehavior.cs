using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Interfaces
{
    public interface IGoombaBehavior : IUpdateable
    {
        public void RunBehavior(GameTime gameTime);
    }
}
