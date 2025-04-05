using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_2.Controls;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameStates
{
    public class TransitionGameState : IGameState
    {
        private KeyboardControl keyboardController;

        public TransitionGameState()
        {
            keyboardController = Game1.Instance.GetKeyboardControl();
            InitControls.InitializeNonPauseProgramCommands(keyboardController);
        }

        public void Update(GameTime gameTime)
        {
            keyboardController.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            // Do nothing
        }
    }
}
