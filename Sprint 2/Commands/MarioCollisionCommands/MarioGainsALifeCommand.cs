using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class MarioGainsALifeCommand : ICommands
    {
        private IPlayer player;
        private GreenMushroom mushroom;
        private Rectangle collisionRect;

        public MarioGainsALifeCommand(IPlayer player, GreenMushroom mushroom, Rectangle collisionRect)
        {
            this.player = player;
            this.mushroom = mushroom;
            this.collisionRect = collisionRect;
        }
        public void Execute() 
        {
            player.RemainingLives++;
            SoundManager.Instance.PlaySoundEffect("1-up");
        }

    }
}
