using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Controls;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.ScreenCamera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameStates
{
    public class GameOverScreen : IGameState
    {
        private KeyboardControl keyboardControl;
        private Camera camera;
        private SpriteFont font;
        
        public GameOverScreen()
        {
            keyboardControl = Game1.Instance.GetKeyboardControl();
            camera = Game1.Instance.GetCamera();
            camera.Reset();

            InitControls.InitializeNonMovementControls(keyboardControl);

            GameObjectManager.Instance.Reset();
            font = Game1.Instance.Content.Load<SpriteFont>("GameOverFont");
        }

        public void Update(GameTime gameTime)
        {
            keyboardControl.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.DrawString(font, "Game Over", MiscConstants.endingTextLocation, color);
            spriteBatch.DrawString(font, "Your Score: " + HUD.Instance.GetScore(), MiscConstants.scoreTextLocation, color);
            spriteBatch.DrawString(font, "Press R to reset", MiscConstants.resetTextLocation, color);
            spriteBatch.DrawString(font, "Press Q to quit", MiscConstants.quitTextLocation, color);
        }
    }
}
