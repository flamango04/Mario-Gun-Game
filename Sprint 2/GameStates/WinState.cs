using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Collision;
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
    public class WinState : IGameState
    {
        private KeyboardControl keyboardControl;
        private CollisionDetection collisionDetection;
        private Camera camera;

        public WinState(KeyboardControl keyboardControl)
        {
            this.keyboardControl = keyboardControl;
            InitControls.InitializeNonMovementControls(keyboardControl);
            collisionDetection = Game1.Instance.CollisionDetection;
            camera = Game1.Instance.GetCamera();
        }
        public void Update(GameTime gameTime)
        {
            keyboardControl.Update();
            foreach (Interfaces.IUpdateable obj in GameObjectManager.Instance.Updateables.ToList())
            {
                obj.Update(gameTime);
            }
            collisionDetection.DetectCollision();
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
