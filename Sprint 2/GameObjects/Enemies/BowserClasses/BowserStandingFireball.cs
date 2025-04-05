using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.BowserClasses
{
    public class BowserStandingFireball : Interfaces.IUpdateable
    {
        private Bowser bowser;
        private IPlayer mario;
        private bool facingLeft;
        private float timeForMouthClosed;
        private const float initialTimeForMouthClosed = 0.60f;

        public BowserStandingFireball(Bowser bowser, bool facingLeft, IPlayer mario)
        {
            this.bowser = bowser;
            this.mario = mario;
            this.facingLeft = facingLeft;
            timeForMouthClosed = initialTimeForMouthClosed;

            if (facingLeft)
            {
                bowser.SetSprite(UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.LeftMouthClosedBowser.ToString()));
            }
            else
            {
                bowser.SetSprite(UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.RightMouthClosedBowser.ToString()));
            }

            
        }

        public void Update(GameTime gameTime)
        {
            float timeElapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeForMouthClosed -= timeElapsed;
            if (timeForMouthClosed < 0)
            {
                BowserFireball fireball = new BowserFireball(new Vector2(bowser.XPos, bowser.YPos), mario.GetHitBox().Bottom, facingLeft);

                GameObjectManager.Instance.Updateables.Add(fireball);
                GameObjectManager.Instance.ForeDrawables.Add(fireball);
                GameObjectManager.Instance.Movers.Add(fireball);

                //Set the bowser sprite to be facing mario
                bowser.LookAtMario();

                timeForMouthClosed = initialTimeForMouthClosed;
            }
        }
    }
}
