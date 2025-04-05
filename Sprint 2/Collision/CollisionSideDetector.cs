

using Microsoft.Xna.Framework;
using System;

namespace Sprint_2.Collision
{
    public class CollisionSideDetector
    {
        public enum side { Top, Bottom, Left, Right }

        public static (Rectangle, side) DetermineCollisionSide(Rectangle sourceRectangle, Rectangle receiverRectangle)
        {
            Rectangle collisionRectangle = Rectangle.Intersect(sourceRectangle, receiverRectangle);
            /* Collision is from the left or right */
            if (collisionRectangle.Height > collisionRectangle.Width)
            {
                if (sourceRectangle.Right > receiverRectangle.Left && sourceRectangle.Right < receiverRectangle.Right)
                {
                    return (collisionRectangle, side.Right);
                }
                else
                {
                    return (collisionRectangle, side.Left);
                }
            }
            /* Collision is top or bottom */
            else
            {
                if (sourceRectangle.Bottom > receiverRectangle.Top && sourceRectangle.Bottom < receiverRectangle.Bottom)
                {
                    return (collisionRectangle, side.Top);
                }
                else
                {
                    return (collisionRectangle, side.Bottom);
                }

            }
        }
    }
}
