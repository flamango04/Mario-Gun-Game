using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Factories;
using Sprint_2.LevelManager;
using Sprint_2.Constants;
using System.Diagnostics;
using System.Windows.Markup;

namespace Sprint_2.GameObjects.ItemSprites
{
    public class RedMushroom : IItem
    {
        public Vector2 Velocity { get; set; }

        public float XPos { get; set; }
        public float YPos { get; set; }

        private ISprite sprite;

        public bool OnSpawn { get; set; }
        private float spawnedYPosition;
        private IBlock sourceBlock;

        private float speed = ItemPhysicsConstants.defaultMoveSpeed;
        private int topOfSourceBlock;

        public RedMushroom(Vector2 initialPosition, int topOfSourceBlock)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;
            Velocity = new Vector2(speed, 0); // Starts moving right

            sprite = UniversalSpriteFactory.Instance.GetItemSprite(nameof(RedMushroom));
            OnSpawn = true;
            spawnedYPosition = initialPosition.Y;

            this.topOfSourceBlock = topOfSourceBlock;
        }


        public void Update(GameTime gameTime)
        {
            if (OnSpawn)
            {
                
                YPos--;
                if (GetHitBox().Bottom < topOfSourceBlock)
                {
                    OnSpawn = false;
                    GameObjectManager.Instance.Movers.Add(this);
                }
            }
            else
            {
                /* Apply Gravity */
                if (Velocity.Y < ItemPhysicsConstants.maxFallVelocity)
                {
                    Velocity += ItemPhysicsConstants.fallVelocity;
                }

                YPos += (float)(Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
                Velocity *= MarioPhysicsConstants.velocityDecay;
                XPos += speed;
            }
            if (YPos > MiscConstants.despawnHeight)
            {
                DeleteItem();
            }
            
            sprite.Update(gameTime);
        }


        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        public void DeleteItem() 
        {
            GameObjectManager.Instance.Movers.Remove(this);
            GameObjectManager.Instance.Updateables.Remove(this);
            GameObjectManager.Instance.BackDrawables.Remove(this);
        }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }

        public void ChangeDirection() {
            speed *= -1;
        }

        public string GetCollisionType()
        {
            return typeof(IItem).Name;
        }

        public int GetColumn()
        {
            if (OnSpawn)
            {
                return -1;
            }
            return (int)(XPos / CollisionConstants.blockWidth);
        }
    }
}

