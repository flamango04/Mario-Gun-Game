using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint_2.Commands.MarioAttackCommands;
using Sprint_2.Commands.ProgramCommands;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System.Collections.Generic;
using System.Diagnostics;
using System.Transactions;

namespace Sprint_2.Controls
{
    public class MouseController : IController
    {
        private MouseState mouseState;
        private MouseState previousState;

        /* Potentially will only have one mouse command */
        private ICommands shoot = new MarioShootCommand(Game1.Instance.mario);
        public MouseController()
        {
            previousState = Mouse.GetState();
        }

        public void Update()
        {
            mouseState = Mouse.GetState();
            /* Only executes shoot on a left click */
            if (mouseState.LeftButton == ButtonState.Pressed && previousState.LeftButton == ButtonState.Released) 
            {
                if (Game1.Instance.mario is GunMarioDecorator)
                {
                    shoot.Execute();
                }
                
            }
            previousState = mouseState;
            
        }

        public Point GetCurrentMousePos()
        {
            return mouseState.Position;
        }
    }
}
