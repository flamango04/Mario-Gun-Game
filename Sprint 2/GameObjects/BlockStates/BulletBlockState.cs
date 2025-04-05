using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sound;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.BlockStates
{
    public class BulletBlockState : BlockState
    {
        private IBlock block;
        private float time = 5.0f;
        private BulletBill.Direction direction;
        private IPlayer mario;
        private bool startBehavior = false;
        public BulletBlockState(IBlock block) : base(block)
        {
            mario = Game1.Instance.mario;
            this.block = block;
            sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.BulletBlock.ToString());
        }

        public override void Update(GameTime gameTime)
        {
            //TODO: add sounds
            time -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if (time < 0 && startBehavior) {
                if (mario.XPos < block.Position.X)
                {
                    direction = BulletBill.Direction.Left;
                } else
                {
                    direction = BulletBill.Direction.Right;
                }

                BulletBill bullet = new BulletBill(new Vector2(block.Position.X, block.Position.Y), direction);
                GameObjectManager.Instance.Movers.Add(bullet);
                GameObjectManager.Instance.Updateables.Add(bullet);
                GameObjectManager.Instance.BackDrawables.Add(bullet);
                time = 5;
            }
            else
            {
                UpdateStartBehavior();
            }
             sprite.Update(gameTime);
        }
        public override void BeHit(IPlayer player){ }
        private void UpdateStartBehavior()
        {
            float distToPlayer = Math.Abs(Game1.Instance.mario.XPos - block.Position.X);
            if (distToPlayer < 400)
            {
                startBehavior = true;
            }

        }
    }
}
