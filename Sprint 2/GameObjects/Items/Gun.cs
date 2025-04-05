using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.MarioStates;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Items
{
    public class Gun : Interfaces.IUpdateable, Interfaces.IDrawable
    {
        private ISprite gunSprite;

        private Vector2 position;
        private float rotation;
        private PlayerStateMachine.Facing playerFacing;
        private IPlayer player;
        private SpriteEffects spriteEffect;

        private Vector2 offset;
        private Rectangle hitBox;
        private Vector2 originOfRotation = Vector2.Zero;
        private Vector2 originToFirePoint;
        private Vector2 firePoint;

        private const float heightScale = 0.375f;
        
        public Gun(IPlayer player, Vector2 location)
        {
            position = location;
            offset = new Vector2(8, 6);

            rotation = 0;
            gunSprite = UniversalSpriteFactory.Instance.GetGunSprite();
            hitBox = gunSprite.GetHitBox(position);


            this.player = player;
            playerFacing = player.GetFacing();

            originToFirePoint = new Vector2(hitBox.Width, 0);
        }

        public void Update(GameTime gameTime)
        {
            
            gunSprite.Update(gameTime);
            UpdateFacing();
            SetPosition(new Vector2(player.XPos, player.YPos));
        }
        private void UpdateRotation()
        {
            Matrix inverseTransform = Matrix.Invert(Game1.Instance.camera.Transform);
            Point mousePos = Game1.Instance.mouseController.GetCurrentMousePos();
            /* Converts the screen coordinates to world coordinates */
            Vector2 mouseInWorldSpace = Vector2.Transform(new Vector2(mousePos.X, mousePos.Y), inverseTransform);
          
            Vector2 rotationDirection = mouseInWorldSpace - position;

            //Debug.WriteLine("Mouse Pos: {0} Gun Position: {1}", mouseInWorldSpace, position);

            rotation = (float)Math.Atan2(rotationDirection.Y, rotationDirection.X);
            if (playerFacing.Equals(PlayerStateMachine.Facing.Right))
            {
                rotation = Math.Clamp(rotation, MathHelper.ToRadians(-90), MathHelper.ToRadians(90));
            }
            else
            {
                rotation += (float)Math.PI;
                /* If rotation is not in section 1 or 4 of the unit circle */
                if (rotation > MathHelper.ToRadians(90) && rotation < MathHelper.ToRadians(270))
                {
                    /* Clamp rotation to nearest section */
                    if (rotation <= MathHelper.ToRadians(180))
                    {
                        rotation = MathHelper.ToRadians(90);

                    }
                    else
                    {
                        rotation = MathHelper.ToRadians(270);

                    }
                }
            }
        }
        private void UpdateFacing()
        {
            playerFacing = player.GetFacing();
            Rectangle playerHitBox = player.GetHitBox();
            if (playerFacing.Equals(PlayerStateMachine.Facing.Left))
            {
                spriteEffect = SpriteEffects.FlipHorizontally;
                originOfRotation = new Vector2(hitBox.Width, 0);
                offset = new Vector2(-hitBox.Width, playerHitBox.Height * heightScale);
                originToFirePoint = new Vector2(-hitBox.Width, 0);
            }
            else
            {
                originOfRotation = Vector2.Zero;
                spriteEffect = SpriteEffects.None;
                offset = new Vector2(hitBox.Width, playerHitBox.Height * heightScale);
                originToFirePoint = new Vector2(hitBox.Width, 0);
            }
        }

        private Vector2 UpdateFirePoint()
        {
            float cos = (float)Math.Cos(rotation);
            float sin = (float)Math.Sin(rotation);
            Vector2 newFirePoint = new Vector2(originToFirePoint.X * cos - originToFirePoint.Y * sin, originToFirePoint.X * sin + originToFirePoint.Y * cos);

            /* Puts the fire point into world coordinates */
            newFirePoint += position;
            return newFirePoint;
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            UpdateRotation();
            //firePoint = UpdateFirePoint();
            gunSprite.Draw(spriteBatch, position, color, rotation, originOfRotation, spriteEffect);
            //HitBoxRectangle.DrawRectangle(spriteBatch, new Rectangle((int)firePoint.X, (int)firePoint.Y, 1, 1),Color.Red, 1);
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position + offset + originOfRotation; 
        }

        public void Shoot()
        {
            UpdateRotation();
            firePoint = UpdateFirePoint();
            /* Create bullet with rotation, firepoint, and direction*/
            Bullet bullet = new Bullet(rotation, firePoint, playerFacing);
            
            GameObjectManager.Instance.Updateables.Add(bullet);
            GameObjectManager.Instance.ForeDrawables.Add(bullet);
            GameObjectManager.Instance.Movers.Add(bullet);
        }
    }
}
