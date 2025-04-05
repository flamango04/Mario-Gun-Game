using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Diagnostics;

namespace Sprint_2.GameObjects
{
    public class FireBar : Interfaces.IUpdateable, Interfaces.IDrawable
    {
        private float xPos;
        private float yPos;
        private IBlock baseBlock;
        private EnemyFireball[] fireballs;
        private float rotation;
        private Vector2 origin;
        private const float initialTimeUntilRotate = 0.15f;
        private float timeUntilRotate = initialTimeUntilRotate;
        private bool startBehavior = false;
        public FireBar(Vector2 location, int numberOfFireballs)
        {
            xPos = location.X;
            yPos = location.Y;
            baseBlock = new Block(NamesOfSprites.SpriteNames.Hit.ToString(), location);
            GameObjectManager.Instance.AddStatic(baseBlock);
            fireballs = new EnemyFireball[numberOfFireballs];
            InitFireballs();

            origin = fireballs[0].GetPosition();
            rotation = MathHelper.ToRadians(11.25f);
        }
        public void Update(GameTime gameTime)
        {
            if (startBehavior = UpdateStartBehavior())
            {
                timeUntilRotate -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (timeUntilRotate < 0)
                {

                    foreach (EnemyFireball fireball in fireballs)
                    {
                        Vector2 fireballPos = fireball.GetPosition();
                        Vector2 distToOrigin = new Vector2(fireballPos.X - origin.X, fireballPos.Y - origin.Y);
                        float cos = (float)Math.Cos(rotation);
                        float sin = (float)Math.Sin(rotation);
                        Vector2 newPos = new Vector2(distToOrigin.X * cos - distToOrigin.Y * sin, distToOrigin.X * sin + distToOrigin.Y * cos);
                        fireball.SetPosition(newPos + origin);
                    }
                    timeUntilRotate = initialTimeUntilRotate;
                }
                foreach (EnemyFireball fireball in fireballs)
                {
                    fireball.Update(gameTime);
                }

                baseBlock.Update(gameTime);
            }
            
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            
            baseBlock.Draw(spriteBatch, color);
            foreach (EnemyFireball fireball in fireballs)
            {
                fireball.Draw(spriteBatch, color);
            }
        }

        private void InitFireballs()
        {
            for (int i = 0; i < fireballs.Length; i++)
            {
                fireballs[i] = new EnemyFireball(new Vector2(xPos + (CollisionConstants.blockWidth / 3f), yPos + (CollisionConstants.blockWidth / 3) ) - new Vector2(0, i * CollisionConstants.blockWidth / 2));
                GameObjectManager.Instance.AddMover( fireballs[i] );
            }
        }
        private bool UpdateStartBehavior()
        {
            float distToPlayer = Math.Abs(Game1.Instance.mario.XPos - xPos);
            if (distToPlayer < EnemyConstants.distUntilBehaviorStarts)
            {
                startBehavior = true;
            }
            return startBehavior;
        }
    }
}
