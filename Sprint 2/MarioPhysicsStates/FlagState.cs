using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Controls;
using Sprint_2.GameObjects.Misc;
using Sprint_2.GameStates;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.MarioStates;
using System;
using System.Diagnostics;
using System.Timers;

namespace Sprint_2.MarioPhysicsStates
{
    public class FlagState : IMarioPhysicsStates
    {
        private IPlayer player;
        private int bottomOfFlagPole;
        private int widthOfFlagPole;
        
        private Timer moveRightTimer;
        public FlagState(int bottomOfFlagPole, int widthOfFlagPole)
        {

            InitControls.InitializeNonPauseProgramCommands(Game1.Instance.GetKeyboardControl());
            player = Game1.Instance.mario;
            this.bottomOfFlagPole = bottomOfFlagPole;
            this.widthOfFlagPole = widthOfFlagPole;

            PlayerStateMachine.Facing facing = player.GetFacing();
            if (facing.Equals(PlayerStateMachine.Facing.Left))
            {
                player.MoveRight();
            }
        }

        public void Update(GameTime gameTime)
        {
            Flag flag = (Flag)GameObjectManager.Instance.BackDrawables.Find((x => x.GetType() == typeof(Flag)));

            if (player.GetHitBox().Bottom != bottomOfFlagPole)
            {
                player.YPos++;
            }
            /* Want this section to happen when the flag has reached the bottom of the pole */
            else if (flag.ReachedBottom())
            {
                player.XPos += widthOfFlagPole;
                player.MoveLeft();
                player.PlayerVelocity = MarioPhysicsConstants.velocityJumpingOffFlagPole;
                player.Jump();
                player.PhysicsState = new Grounded(player);

                Timer timer = new Timer(MarioPhysicsConstants.timeToReachCastle);
                moveRightTimer = new Timer(MarioPhysicsConstants.timeBetweenMovementForAnimations);

                moveRightTimer.Elapsed += (source, e) => MoveRight(source, e, player);
                moveRightTimer.Enabled = true;
                moveRightTimer.AutoReset = true;

                timer.Elapsed += (source, e) => OnTimedEvent(source, e, player, moveRightTimer);
                timer.Enabled = true;
                timer.AutoReset = false;
                
            }
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e, IPlayer player, Timer moveRightTimer)
        {
            GameObjectManager.Instance.BackDrawables.Remove(player);

            moveRightTimer.Dispose();

            switch (GameWorldManager.CurrentGameWorld)
            {
                case "main-menu":
                    Game1.Instance.gameState = new WinScreen();
                    break;

                case "level-1_data_pretty":
                    Spawner.Instance.TeleportToLevel(@"XMLFiles\level-2", Vector2.Zero, "mainTheme");
                    Game1.Instance.gameState = new PlayableState(Game1.Instance.GetKeyboardControl());
                    HUD.Instance.ResetTime();
                    Game1.Instance.GetCamera().Reset();
                    HUD.Instance.IncrementLevel();
                    break;


                case @"XMLFiles\level-2":
                    Spawner.Instance.TeleportToLevel(@"XMLFiles\extraLevel", new Vector2(100, 400), "underworld");
                    Game1.Instance.gameState = new PlayableState(Game1.Instance.GetKeyboardControl());
                    HUD.Instance.ResetTime();
                    Game1.Instance.GetCamera().Reset();
                    HUD.Instance.IncrementLevel();
                    break;

                case @"XMLFiles\extraLevel":
                    Debug.WriteLine("Entered level 3 case");
                    Spawner.Instance.TeleportToLevel(@"XMLFiles\boss-level", Vector2.Zero, "castle");
                    Game1.Instance.gameState = new PlayableState(Game1.Instance.GetKeyboardControl());
                    HUD.Instance.ResetTime();
                    Game1.Instance.GetCamera().Reset();
                    HUD.Instance.IncrementLevel();
                    break;

                default:
                    // Handle unknown world (fallback logic)
                    Game1.Instance.gameState = new WinScreen();
                    break;
            }
        }

        private static void MoveRight(Object source, ElapsedEventArgs e, IPlayer player)
        {
            player.MoveRight();
        }
    }
}
