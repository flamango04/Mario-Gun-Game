using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Sound;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Timers;

namespace Sprint_2.GameObjects.Enemies.BowserClasses
{
    public class Bowser : IEnemy
    {
        private ISprite sprite;
        private IPlayer mario;
        private bool facingLeft = true;
        public float XPos { get; set; }
        public float YPos { get; set; }
        public Vector2 Velocity { get; set; }
        public bool Flipped { get; set; }
        private float leftMostXPos;
        private float rightMostXPos;
        private const int patrolRange = 32;

        private int health = EnemyConstants.initialBowserHealth;
        private bool isJumping = false;

        private Interfaces.IUpdateable bowserBehavior;
        private Random rand;
        private Timer attackTimer;
        private bool startBehavior = false;
        private SpriteEffects spriteEffect = SpriteEffects.None;

        private Interfaces.IUpdateable previousBowserBehavior;
        private int repeatBehavior = 0;
        public Bowser(Vector2 location)
        {
            XPos = location.X;
            YPos = location.Y;
            
            leftMostXPos = XPos - patrolRange;
            rightMostXPos = XPos + patrolRange;

            Velocity = new Vector2(EnemyConstants.bowserXMoveSpeed, 0f);
            mario = Game1.Instance.mario;
            //Assume bowser starts facing left
            sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.LeftBowser.ToString());

            bowserBehavior = new BowserPatrolBehavior(this);
            previousBowserBehavior = bowserBehavior;
            rand = new Random();

        }

        private void OnTimedEvent(Object source, EventArgs e)
        {

            Interfaces.IUpdateable newBowserBehavior = GetBowserBehavior();

            /* If the new attack is the same as the old one */
            if (previousBowserBehavior.GetType().Equals(newBowserBehavior.GetType()))
            {
                repeatBehavior++;
                /* Generate a new attack as many times as the attack has been repeated*/
                for (int i = 0; i < repeatBehavior; i++)
                {
                    newBowserBehavior = GetBowserBehavior();
                    /* If a new attack was generated */
                    if (!newBowserBehavior.GetType().Equals(previousBowserBehavior.GetType()))
                    {
                        repeatBehavior = 0;
                        break;
                    }
                }

            }
            else
            {
                repeatBehavior = 0;
            }
            bowserBehavior = newBowserBehavior;
            previousBowserBehavior = newBowserBehavior;
        }
        private Interfaces.IUpdateable GetBowserBehavior()
        {
            Interfaces.IUpdateable newBowserBehavior;
            int randInt = rand.Next(5);
            if (randInt == 0)
            {
                newBowserBehavior = new BowserJumpBehavior(this);
                SoundManager.Instance.PlaySoundEffect("jump");
            }
            else if (randInt == 1)
            {
                newBowserBehavior = new BowserStandingFireball(this, facingLeft, mario);
                SoundManager.Instance.PlaySoundEffect("bowserfire");
            }
            else if (randInt == 2)
            {
                newBowserBehavior = new BowserJumpingFireball(this, facingLeft, mario);
                SoundManager.Instance.PlaySoundEffect("bowserfire");
            }
            else if (randInt == 3)
            {
                newBowserBehavior = new BowserHammerAttack(this, facingLeft);
                SoundManager.Instance.PlaySoundEffect("fireworks");
            }
            else
            {
                newBowserBehavior = new BowserPatrolBehavior(this);
            }

            return newBowserBehavior;
        }

        public void Update(GameTime gameTime)
        {
            startBehavior = UpdateStartBehavior();
            if (startBehavior)
            {
                bowserBehavior.Update(gameTime);
                ChangeDirection();

                sprite.Update(gameTime);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color, 0f, Vector2.Zero, spriteEffect);
        }
        public void TakeFireballDamage()
        {
            /* Subtract health by 1 */
            health--;
            if (health == 0)
            {
                attackTimer.Dispose();
                bowserBehavior = new BowserFlippedBehavior(this);
                spriteEffect = SpriteEffects.FlipVertically;

                HUD.Instance.AddScorePopUp(5000, new Vector2(XPos, YPos));
            }
        }
        public void SetBowserBehaviorToFall()
        {
            attackTimer.Dispose();
            bowserBehavior = new BowserFallBehavior(this);
        }
        public void TakeStompDamage()
        {
            //Bowser can not take stomp damage
        }

        public void ChangeDirection()
        {
            /* Always needs to look at mario */
            if (mario.XPos > XPos && facingLeft)
            {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.RightBowser.ToString());
                facingLeft = !facingLeft;
            }
            else if (XPos > mario.XPos && !facingLeft)
            {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.LeftBowser.ToString());
                facingLeft = !facingLeft;
            }
        }
        public void LookAtMario()
        {
            if (mario.XPos < XPos)
            {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.LeftBowser.ToString());
                facingLeft = true;
            }
            else
            {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.RightBowser.ToString());
                facingLeft = false;
            }
        }
        public string GetCollisionType()
        {
            return nameof(Bowser);
        }
        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }
        public int GetColumn()
        {
            return (int)XPos / CollisionConstants.blockWidth;
        }
        public void SetIsJumping(bool jumping)
        {
            isJumping = jumping;
        }
        public void SetSprite(ISprite newSprite)
        {
            sprite = newSprite;
        }
        public (float, float) GetMaxPatrolBounds()
        {
            return (leftMostXPos, rightMostXPos);
        }
        private bool UpdateStartBehavior()
        {
            float distToPlayer = Math.Abs(Game1.Instance.mario.XPos - XPos);
            if (distToPlayer < EnemyConstants.distUntilBehaviorStarts && !startBehavior)
            {
                startBehavior = true;
                attackTimer = new Timer(1000);
                attackTimer.Enabled = true;
                attackTimer.Elapsed += (source, e) => OnTimedEvent(source, e);
                attackTimer.AutoReset = true;
            }
            return startBehavior;
        }
    }
}
