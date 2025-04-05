using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using Sprint_2.LevelManager;
using System.ComponentModel;

namespace Sprint_2.GameObjects.Items
{
    public class StaticCoin : IItem
    {
        public Vector2 Velocity { get; set; }
        public bool OnSpawn { get; set; } = true;
        private ISprite sprite;
        public float XPos { get; set; }
        public float YPos { get; set; }


        public StaticCoin(Vector2 location)
        {
            sprite = UniversalSpriteFactory.Instance.GetStaticCoinSprite();
            XPos = location.X;
            YPos = location.Y;

        }

        public void Update(GameTime gameTime)
        {   
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }
        public void DeleteItem() 
        {
            GameObjectManager.Instance.Updateables.Remove(this);
            GameObjectManager.Instance.ForeDrawables.Remove(this);
            GameObjectManager.Instance.Static.Remove(this);
        }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }

        public void ChangeDirection() { }

        public string GetCollisionType()
        {
            return typeof(StaticCoin).Name;
        }

        public int GetColumn()
        {
            return (int)(XPos / CollisionConstants.blockWidth);
        }
    }
}
