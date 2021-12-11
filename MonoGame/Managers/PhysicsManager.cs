using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoTest.GameObjects;
using MonoTest.Map.Tiles;

namespace MonoTest.Managers
{
    class PhysicsManager
    {
        private const float Gravity = 300f;
        public void Move(Moveable moveable, float deltaTime, IEnumerable<IGameObject> map)
        {
            moveable.IsIntersecting = false;
            
            deltaTime /= 1000;
            if(!moveable.IsTouchingGround) moveable.Velocity = new Vector2(moveable.Velocity.X, moveable.Velocity.Y + Gravity * deltaTime);
            var newPosition = moveable.Position + moveable.Velocity * new Vector2(deltaTime, deltaTime);
            var moveableHitBox = moveable.CurrentAnimation.CurrentHitbox;
            moveableHitBox.X += (int)newPosition.X;
            moveableHitBox.Y += (int)newPosition.Y;

            foreach (var mapObject in map)
            {
                if (mapObject == moveable) continue;
                if (mapObject is Tile { IsPassable: false } tile)
                {
                    if (moveableHitBox.Intersects(tile.BoundingBox))
                    {
                        moveable.IsIntersecting = true;
                        if (moveableHitBox.Bottom >= tile.BoundingBox.Top)
                        {
                            if(moveable.Velocity.Y >= 0)
                            {
                                moveable.Velocity = new Vector2(moveable.Velocity.X, 0);
                                moveable.IsTouchingGround = true;
                                newPosition.Y = moveable.Position.Y;
                            }
                        }

                        if (moveableHitBox.Right >= tile.BoundingBox.Left || moveableHitBox.Left >= tile.BoundingBox.Right)
                        {
                            moveable.Velocity = new Vector2(0, moveable.Velocity.Y);
                            newPosition.X = moveable.Position.X;

                        }
                    }
                }
            }
            
            moveable.Position = newPosition;
        }
    }
}