using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System.ComponentModel;

namespace Sprint_2.GameObjects.ItemSprites
{
    public class Coin : IItem
    {
        public Vector2 Velocity { get; set; }
        public bool OnSpawn { get; set; } = true;
        private ISprite sprite;
        public float XPos { get; set; }
        public float YPos { get; set; }


        private int heightIncrease = ItemPhysicsConstants.coinHeightChange;
        private bool moveDown = false;

        private float originalHeight;
        private bool fromBlock;

        public Coin(Vector2 location, bool fromBlock)
        {
            sprite = UniversalSpriteFactory.Instance.GetItemSprite(nameof(Coin));
            XPos = location.X;
            YPos = location.Y;
            originalHeight = YPos;

            this.fromBlock = fromBlock;
        }

        public void Update(GameTime gameTime)
        {
            if (fromBlock)
            {
                YPos += heightIncrease;
                if (YPos < originalHeight - ItemPhysicsConstants.coinHeightIncrease)
                {
                    heightIncrease *= -1;
                }
                else if (YPos > originalHeight)
                {
                    DeleteItem();
                }
            }
            
            
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }
        public void DeleteItem() 
        {
            GameObjectManager.Instance.Updateables.Remove(this);
            GameObjectManager.Instance.BackDrawables.Remove(this);
        }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }

        public void ChangeDirection() { }

        public string GetCollisionType()
        {
            return typeof(Coin).Name;
        }

        public int GetColumn()
        {
            return (int)(XPos / CollisionConstants.blockWidth);
        }
    }
}
