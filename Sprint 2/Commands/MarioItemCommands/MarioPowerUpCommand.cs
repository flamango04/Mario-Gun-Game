using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Sprint_2.Constants;

namespace Sprint_2.Commands.MarioItemCommands
{
    public class MarioPowerUpCommand : ICommands
    {
        private IPlayer mario;
        private IItem item;

        public MarioPowerUpCommand(IPlayer mario, IItem item, Rectangle collisionRect)
        {
            this.mario = mario;
            this.item = item;
        }

        public void Execute()
        {
            // Used for testing will be deleted later
            if (item != null)
            {
                HUD.Instance.AddScorePopUp(MiscConstants.powerUpPoints, new Vector2(item.XPos, item.YPos));
            }
            //SoundManager.Instance.PlaySoundEffect("1-up");
            mario.PowerUp();
        }
    }
}
