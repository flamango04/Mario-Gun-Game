using Microsoft.Xna.Framework;
using Sprint_2.LevelManager;
using Sprint_2.Sound;


namespace Sprint_2.GameObjects.Enemies.BowserClasses
{
    public class BowserHammerAttack : Interfaces.IUpdateable
    {
        private Bowser bowser;
        private bool facingLeft;

        private Interfaces.IUpdateable bowserBehavior;

        private float timeToSpawnNextHammer;
        private const float initialTimeToSpawnHammer = 0.25f;

        public BowserHammerAttack(Bowser bowser, bool facingLeft)
        {
            this.bowser = bowser;

            this.facingLeft = facingLeft;


            timeToSpawnNextHammer = initialTimeToSpawnHammer;
            bowserBehavior = new BowserJumpBehavior(bowser);
        }

        public void Update(GameTime gameTime)
        {
            bowserBehavior.Update(gameTime);

            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeToSpawnNextHammer -= elapsedTime;
            if (timeToSpawnNextHammer < 0)
            {
                BowserHammer bowserHammer = new BowserHammer(new Vector2(bowser.XPos, bowser.YPos), facingLeft);

                GameObjectManager.Instance.BackDrawables.Add(bowserHammer);
                GameObjectManager.Instance.Updateables.Add(bowserHammer);
                GameObjectManager.Instance.Movers.Add(bowserHammer);

                timeToSpawnNextHammer = initialTimeToSpawnHammer;
            }
            
        }
    }
}
