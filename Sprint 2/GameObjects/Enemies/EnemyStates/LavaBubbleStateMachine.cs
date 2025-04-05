using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Collision;
using Sprint_2.Commands.MarioMovementCommands;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sprites.EnemySprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public class LavabubbleStateMachine
    {
        private LavaBubble lavaBubble;
        private ISprite sprite;

        private bool movingUp = true;
        private bool startBehavior = false;
        private int maxHeight;
        private int minHeight;

        public LavabubbleStateMachine(LavaBubble lavaBubble, int maxHeight)
        {
            this.lavaBubble = lavaBubble;
            this.maxHeight = maxHeight;
            minHeight = (int)lavaBubble.YPos;

            sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.LavaBubbleMovingUp.ToString());
        }

        public void Update(GameTime gameTime, float yPos)
        {
            startBehavior = UpdateStartBehavior();
            if (startBehavior)
            {
                Move(gameTime);

                ChangeMovement(yPos);
            }
            sprite.Update(gameTime);
        }
        private bool UpdateStartBehavior()
        {
            float distToPlayer = Math.Abs(Game1.Instance.mario.XPos - lavaBubble.XPos);
            if (distToPlayer < EnemyConstants.distUntilBehaviorStarts)
            {
                startBehavior = true;
            }
            return startBehavior;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            sprite.Draw(spriteBatch, location, color);
        }

        public void Move(GameTime gameTime)
        {
            lavaBubble.YPos += (float) (lavaBubble.Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
        }

        public void ChangeMovement(float Ypos)
        {
            if (Ypos < maxHeight && lavaBubble.Velocity.Y < 0)
            {
                lavaBubble.Velocity = new Vector2(0, -lavaBubble.Velocity.Y);
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.LavaBubbleMovingDown.ToString());
            }
            else if (Ypos > minHeight && lavaBubble.Velocity.Y > 0)
            {
                lavaBubble.Velocity = new Vector2(0, -lavaBubble.Velocity.Y);
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.LavaBubbleMovingUp.ToString());
            }
        }

        public Rectangle GetHitBox(Vector2 location)
        {
            return sprite.GetHitBox(location);
        }
    }
}
