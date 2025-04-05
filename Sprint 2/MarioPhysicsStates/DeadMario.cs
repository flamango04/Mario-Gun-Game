using Microsoft.Xna.Framework;
using Sprint_2.Commands.ProgramCommands;
using Sprint_2.Constants;
using Sprint_2.Controls;
using Sprint_2.GameStates;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.MarioPhysicsStates
{
    public class DeadMario : IMarioPhysicsStates
    {
        private IPlayer mario;

        public DeadMario(IPlayer mario)
        {
            this.mario = mario;
            mario.PlayerVelocity = Vector2.Zero;
            InitControls.InitializeNonPauseProgramCommands(Game1.Instance.GetKeyboardControl());
        }

        public void Update(GameTime gameTime)
        {
            if (mario.PlayerVelocity.Y < MarioPhysicsConstants.maxFallVelocity)
            {
                mario.PlayerVelocity += MarioPhysicsConstants.marioFallVelocity;
            }

            mario.XPos += (int)(mario.PlayerVelocity.X * gameTime.ElapsedGameTime.TotalSeconds);
            mario.YPos += (int)(mario.PlayerVelocity.Y * gameTime.ElapsedGameTime.TotalSeconds);

            mario.PlayerVelocity *= MarioPhysicsConstants.velocityDecay;

            
            if (mario.YPos > EnemyConstants.despawnHeight)
            {
                if (mario.RemainingLives == 0)
                {
                    Game1.Instance.gameState = new GameOverScreen();
                }
                else
                {
                    Game1.Instance.Reload();
                }
                
            }
        }
    }
}
