
using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sprint_2.Collision
{
    public class CollisionDetection
    {
        private CollisionResponse collisionResponse;
        public CollisionDetection()
        {
            collisionResponse = new CollisionResponse();
        }
        public void DetectCollision()
        {
            foreach(ICollideable mover in GameObjectManager.Instance.Movers.ToList())
            {
                
                int column = mover.GetColumn();
                List<ICollideable> nearbyBlocks = GameObjectManager.Instance.GetNearbyBlocks(column);


                var staticObjects = GameObjectManager.Instance.Static?.ToList();
                if (staticObjects != null && staticObjects.Any())
                {
                    foreach (ICollideable nonmover in GameObjectManager.Instance.Static.ToList())
                    {
                        if (mover.GetHitBox().Intersects(nonmover.GetHitBox()))
                        {
                            Rectangle collisionRect;
                            CollisionSideDetector.side side;
                            (collisionRect, side) = CollisionSideDetector.DetermineCollisionSide(mover.GetHitBox(), nonmover.GetHitBox());

                            collisionResponse.ResolveCollision(mover, nonmover, side.ToString(), collisionRect);
                        }
                    }
                }
                GameObjectManager.Instance.RemoveBlocksFromStatic(nearbyBlocks);
            }
            foreach(ICollideable mover1 in GameObjectManager.Instance.Movers.ToList())
            {
                foreach(ICollideable mover2 in GameObjectManager.Instance.Movers.ToList())
                {
                    if (!mover1.Equals(mover2) && mover1.GetHitBox().Intersects(mover2.GetHitBox()))
                    {
                        Rectangle collisionRect;
                        CollisionSideDetector.side side;
                        (collisionRect, side) = CollisionSideDetector.DetermineCollisionSide(mover1.GetHitBox(), mover2.GetHitBox());

                        collisionResponse.ResolveCollision(mover1, mover2, side.ToString(), collisionRect);
                    }
                }
            }
        }
    }
}
