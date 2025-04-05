using Microsoft.Xna.Framework;
using Sprint_2.GameObjects;
using Sprint_2.GameStates;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;


namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class MarioCollidesWithCameraCollider : ICommands
    {
        private IPlayer player;
        private Collider collider;
        private Rectangle collisionRect;

        public MarioCollidesWithCameraCollider(IPlayer player, Collider collider, Rectangle collisionRect)
        {
            this.player = player;
            this.collider = collider;
            this.collisionRect = collisionRect;
        }

        public void Execute()
        {
            GameObjectManager.Instance.RemoveNonUpdatingStatic(collider);
            Game1.Instance.gameState = new NoCameraUpdatingState(Game1.Instance.GetKeyboardControl());
            
        }
    }
}
