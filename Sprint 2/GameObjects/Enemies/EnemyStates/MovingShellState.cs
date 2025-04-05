using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public class MovingShellState : AbstractShellState
    {
        public MovingShellState(Shell shell) : base(shell) 
        {

        }

        public override void Update(GameTime gameTime)
        {
            UpdatePosition(gameTime);
        }
    }
}
