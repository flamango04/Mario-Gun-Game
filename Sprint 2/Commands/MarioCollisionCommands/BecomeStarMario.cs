using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class BecomeStarMario : ICommands
    {
        private IPlayer player;
        private Star star;
        private Rectangle collisionRectangle;

        public BecomeStarMario(IPlayer player, Star star, Rectangle collisionRectangle)
        {
            this.player = player;
            this.star = star;
            this.collisionRectangle = collisionRectangle;
        }

        public void Execute()
        {
            GameObjectManager.Instance.BackDrawables.Remove(player);
            GameObjectManager.Instance.Updateables.Remove(player);
            GameObjectManager.Instance.Movers.Remove(player);

            Game1.Instance.mario = new StarMario(player);
            GameObjectManager.Instance.BackDrawables.Add(Game1.Instance.mario);
            GameObjectManager.Instance.Updateables.Add(Game1.Instance.mario);
            GameObjectManager.Instance.Movers.Add(Game1.Instance.mario);
        }
    }
}
