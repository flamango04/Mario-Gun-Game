using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using Sprint_2.Sound;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioAttackCommands
{
    public class MarioShootCommand : ICommands
    {
        private IPlayer player;

        public MarioShootCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player = Game1.Instance.mario;
            if (player is GunMarioDecorator)
            {

                SoundManager.Instance.PlaySoundEffect("fireball");

                GunMarioDecorator gunMario = (GunMarioDecorator)player;
                gunMario.ShootGun();
            }
        }
    }
}
