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
    public class PlayableState : IGameState
    {
        private KeyboardControl keyboardControl;
        private CollisionDetection collisionDetection;
        private Camera camera;

        public PlayableState(KeyboardControl keyboardControl)
        {
            this.keyboardControl = keyboardControl;
            InitControls.initializeControls(keyboardControl, Game1.Instance.mario);
            collisionDetection = Game1.Instance.CollisionDetection;
            camera = Game1.Instance.GetCamera();
        }
        public void Update(GameTime gameTime)
        {
            keyboardControl.Update();
            HUD.Instance.Update(gameTime);
            camera.Update(gameTime);


            var updateableObjects = GameObjectManager.Instance.Updateables.ToList();
            foreach (Interfaces.IUpdateable obj in updateableObjects)
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
