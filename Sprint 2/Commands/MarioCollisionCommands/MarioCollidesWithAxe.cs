using Microsoft.Xna.Framework;
using Sprint_2.GameObjects;
using Sprint_2.GameObjects.Enemies.BowserClasses;
using Sprint_2.GameObjects.Misc;
using Sprint_2.GameStates;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sound;
using Sprint_2.MarioPhysicsStates;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Timers;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class MarioCollidesWithAxe : ICommands
    {
        private IPlayer mario;
        private Axe axe;
        private Rectangle collisionRect;

        public MarioCollidesWithAxe(IPlayer mario, Axe axe, Rectangle collisionRect)
        {
            this.mario = mario;
            this.axe = axe;
            this.collisionRect = collisionRect; 
        }

        public void Execute()
        {
            Bridge bridge = (Bridge)GameObjectManager.Instance.ForeDrawables.Find((x => x.GetType() == typeof(Bridge)));
            bridge.DeleteBridge();
            Game1.Instance.gameState = new WinState(Game1.Instance.GetKeyboardControl());
            //
            SoundManager.Instance.PlayBGM("levelComplete");

            //
            Bowser bowser = (Bowser)GameObjectManager.Instance.ForeDrawables.Find((x => x.GetType() == typeof(Bowser)));
            if (bowser != null)
            {
                bowser.SetBowserBehaviorToFall();
            }
            Collider collider = (Collider)GameObjectManager.Instance.Static.Find((x => 
            (x is Collider ? ((Collider)x).GetCollisionType() : x.GetType().ToString()) == "Barrier"));
            Debug.WriteLine("Collider : " + collider);
            mario.PlayerVelocity = new Vector2(0, mario.PlayerVelocity.Y);
            GameObjectManager.Instance.RemoveNonUpdatingStatic(collider);

            Timer transitionToWinAnimation = new Timer(2000);
            transitionToWinAnimation.AutoReset = false;
            transitionToWinAnimation.Enabled = true;
            transitionToWinAnimation.Elapsed += (source, e) => OnTimedEvent(source, e);
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Game1.Instance.gameState = new EndOfDemoGameState(Game1.Instance.GetKeyboardControl());
            Game1.Instance.mario.PhysicsState = new EndOfDemoPhysicsState();
        }
    }
}
