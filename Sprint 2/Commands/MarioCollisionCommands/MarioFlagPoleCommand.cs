using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.GameObjects.Misc;
using Sprint_2.GameStates;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.MarioPhysicsStates;
using Sprint_2.MarioStates;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class MarioFlagPoleCommand : ICommands
    {
        private IPlayer player;
        private ICollideable collideable;
        private Rectangle collisionRect;

        

        public MarioFlagPoleCommand(IPlayer player, ICollideable collideable, Rectangle collisionRect)
        {
            this.player = player;
            this.collideable = collideable;
            this.collisionRect = collisionRect;
            
        }

        public void Execute()
        {
            if (player is StarMario)
            {
                StarMario starMario = (StarMario)player;
                starMario.RemoveStar();

            }
            else if (player is GunMarioDecorator)
            {
                ((GunMarioDecorator)player).RemoveGun();
            }
            CalculatePointsEarned(collisionRect.Bottom, collideable.GetHitBox().Top);

            //
            Game1.Instance.gameState = new WinState(Game1.Instance.GetKeyboardControl());
            //
            /* Only need to collide with it once */
            GameObjectManager.Instance.Static.Remove(collideable);

            player.Climb();
            player.PhysicsState = new FlagState(collideable.GetHitBox().Bottom, collideable.GetHitBox().Width);
            
            
            /* Want to get the flag sprite to move down */
            Flag flag = (Flag)GameObjectManager.Instance.BackDrawables.Find((x => x.GetType() == typeof(Flag)));
            GameObjectManager.Instance.Updateables.Add(flag);
        }

        private void CalculatePointsEarned(int bottomOfCollision, int YPosOfFlagPole)
        {
            int locationRelativeToFlagPole = bottomOfCollision - YPosOfFlagPole;
            int score = 0;

            bool scoreFound = false;
            foreach (KeyValuePair<(int, int), int> entry in MiscConstants.flagPoints)
            {
                if (entry.Key.Item1 < locationRelativeToFlagPole && locationRelativeToFlagPole <= entry.Key.Item2)
                {
                    score = entry.Value;
                    scoreFound = true;
                    break;
                }
            }
            if (!scoreFound)
            {
                score = MiscConstants.maxFlagScore;
            }
            HUD.Instance.AddScore(score);
        }
    }
}
