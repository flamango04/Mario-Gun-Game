using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.Items;
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
    public class BecomeGunMario : ICommands
    {
        private IPlayer player;
        private GunPickup gunPickup;
        private Rectangle collisionRect;

        public BecomeGunMario(IPlayer player, GunPickup gunPickup, Rectangle collisionRect)
        {
            this.player = player;
            this.gunPickup = gunPickup;
            this.collisionRect = collisionRect;
        }

        public void Execute()
        {
            if (player is not GunMarioDecorator)
            {
                GameObjectManager.Instance.BackDrawables.Remove(player);
                GameObjectManager.Instance.Updateables.Remove(player);
                GameObjectManager.Instance.Movers.Remove(player);

                player = new GunMarioDecorator(player);
                Game1.Instance.mario = player;

                GameObjectManager.Instance.BackDrawables.Add(player);
                GameObjectManager.Instance.Updateables.Add(player);
                GameObjectManager.Instance.Movers.Add(player);
            }
            
            
        }
    }
}
