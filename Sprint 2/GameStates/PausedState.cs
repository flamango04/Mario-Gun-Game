using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Controls;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameStates
{
    public class PausedState : IGameState
    {
        private KeyboardControl keyboardControl;
        public PausedState(KeyboardControl keyboardControl)
        {
            this.keyboardControl = keyboardControl;
            InitControls.InitializeNonMovementControls(keyboardControl);
        }

        public void Update(GameTime gameTime)
        {
            keyboardControl.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            foreach (Interfaces.IDrawable obj in GameObjectManager.Instance.BackDrawables.ToList())
            {
                obj.Draw(spriteBatch, Color.White);
            }
            foreach (Interfaces.IDrawable obj in GameObjectManager.Instance.ForeDrawables.ToList())
            {
                obj.Draw(spriteBatch, Color.White);
            }

            HUD.Instance.Draw(spriteBatch);
        }
    }
}
