using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.Constants;
using System;
using System.Diagnostics;
using Sprint_2.Sprites;
using Sprint_2.LevelManager;


namespace Sprint_2.GameObjects
{
    public class FireBall : IProjectile
    {
        private ISprite fireball;
        public float XPos { get; set; }
        public float YPos { get; set; }
        public Vector2 Speed { get; set; }

        private int fireballSpawn;

        private float totalTime;
        private IPlayer source;
        double distFromSource;

        public bool EnteredExplosionState { get; set; } = false;

        private bool FinishedExplosionAnimation = false;
        private float timer;

        private Rectangle playerSource;
        public FireBall(IPlayer source, Vector2 speed)
        {
            this.source = source;
            XPos = source.XPos;
            YPos = source.YPos;

            playerSource = source.GetHitBox();


            Speed = speed;
            fireball = UniversalSpriteFactory.Instance.MarioFireball();

            fireballSpawn = (int)YPos;  
        }
        public void Update(GameTime gameTime) 
        {
            if (!EnteredExplosionState)
            {
                if (Speed.Y < FireBallConstants.maxFallSpeed)
                {
                    Speed += FireBallConstants.fallSpeed;
                }

                Speed = new Vector2(Speed.X, Speed.Y * MarioPhysicsConstants.velocityDecay);
                XPos += (float)(Speed.X * gameTime.ElapsedGameTime.TotalSeconds);
                YPos += (float)(Speed.Y * gameTime.ElapsedGameTime.TotalSeconds);
                

                //Calculates distance from the fireball and the Player
                distFromSource = Math.Sqrt(Math.Pow(XPos - source.XPos, 2) + Math.Pow(YPos - source.YPos, 2));
            }
            
            //If the fireBall is too far away from the player that threw it, the fireball will explode
            if (distFromSource > FireBallConstants.explosionRange && !EnteredExplosionState)
            {
                fireball = UniversalSpriteFactory.Instance.MarioFireballExplosion();
                EnteredExplosionState = true;
            }
            
            if (EnteredExplosionState)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (timer > FireBallConstants.timeToFinishExplosion)
                {
                    FinishedExplosionAnimation = true;
                }
            }
            fireball.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            fireball.Draw(spriteBatch, new Vector2(XPos, YPos), color);  
        }

        public bool isExploded()
        {
            return FinishedExplosionAnimation;
        }

        public void ChangeSprite(ISprite sprite)
        {
            if (!EnteredExplosionState)
            {
                fireball = sprite;
            }
        }

        public Rectangle GetHitBox()
        {
            return fireball.GetHitBox(new Vector2(XPos, YPos));
        }

        public string GetCollisionType()
        {
            if (EnteredExplosionState)
            {
                return "";
            }
            return typeof(IProjectile).Name;
        }

        public int GetColumn()
        {
            return (int)(XPos / CollisionConstants.blockWidth);
        }
    }
}
