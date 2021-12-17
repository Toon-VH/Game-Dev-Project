using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using MonoTest.GameObjects;
using MonoTest.Map.Tiles;

namespace MonoTest.Managers
{
    class PhysicsManager
    {
        private const float Gravity = 350f;
        private static Vector2 prevVelocity;
        private static Vector2 prevPosition;

        public void Move(Moveable moveable, float deltaTime, IEnumerable<IGameObject> map)
        {
            // if (prevVelocity != moveable.Velocity)
            // {
            //     Debug.WriteLine($"Velocity =  {moveable.Velocity}");
            // }
            //
            // if (prevPosition != moveable.Position)
            // {
            //     Debug.WriteLine($"Position =  {moveable.Position}");
            // }

            prevVelocity = moveable.Velocity;
            prevPosition = moveable.Position;
            moveable.IsIntersecting = false;
            
            moveable.Velocity = new Vector2(moveable.Velocity.X, moveable.Velocity.Y + Gravity * deltaTime);
            
            var newPosition = moveable.Position;

            //Update one axis at a time
            newPosition += new Vector2(0, moveable.Velocity.Y * deltaTime);
            CheckCollisions(Direction.Vertical, moveable,newPosition, map);
            newPosition = moveable.Position;
            newPosition += new Vector2(moveable.Velocity.X * deltaTime, 0);
            CheckCollisions(Direction.Horizontal, moveable, newPosition, map);
        }
        
        private bool Intersects(RectangleF player, Rectangle block, Direction direction, out Vector2 depth)
        {
            if (player.Intersects(block))
            {
                if (direction == Direction.Vertical)
                    depth = new Vector2(0, GetVerticalIntersectionDepth(player, block));
                else depth = new Vector2(GetHorizontalIntersectionDepth(player, block), 0);
                return depth.Y != 0 || depth.X != 0;
            }

            depth = Vector2.Zero;
            return false;
        }

        private float GetHorizontalIntersectionDepth(RectangleF rectA, Rectangle rectB)
        {
            // Calculate half sizes.
            float halfWidthA = rectA.Width / 2.0f;
            float halfWidthB = rectB.Width / 2.0f;

            // Calculate centers.
            float centerA = rectA.Left + halfWidthA;
            float centerB = rectB.Left + halfWidthB;

            // Calculate current and minimum-non-intersecting distances between centers.
            float distanceX = centerA - centerB;
            float minDistanceX = halfWidthA + halfWidthB;

            // If we are not intersecting at all, return (0, 0).
            if (Math.Abs(distanceX) >= minDistanceX)
                return 0f;

            // Calculate and return intersection depths.
            return distanceX > 0 ? minDistanceX - distanceX : -minDistanceX - distanceX;
        }

        private float GetVerticalIntersectionDepth(RectangleF rectA, Rectangle rectB)
        {
            // Calculate half sizes.
            float halfHeightA = rectA.Height / 2.0f;
            float halfHeightB = rectB.Height / 2.0f;

            // Calculate centers.
            float centerA = rectA.Top + halfHeightA;
            float centerB = rectB.Top + halfHeightB;

            // Calculate current and minimum-non-intersecting distances between centers.
            float distanceY = centerA - centerB;
            float minDistanceY = halfHeightA + halfHeightB;

            // If we are not intersecting at all, return (0, 0).
            if (Math.Abs(distanceY) >= minDistanceY)
                return 0f;
            
            // Calculate and return intersection depths.
            return distanceY > 0 ? minDistanceY - distanceY : -minDistanceY - distanceY;
        }

        private void CheckCollisions(Direction direction, Moveable moveable, Vector2 newPosition, IEnumerable<IGameObject> map)
        {
            var moveableHitBox = moveable.CurrentAnimation.CurrentHitbox;
            moveableHitBox.X += newPosition.X;
            moveableHitBox.Y += newPosition.Y;
            Debug.WriteLine(moveableHitBox.Position);
            //Get a list of objects to test against
            //You probably already have a mechanism for this

            //Loop and check for collisions on these objects
            foreach (var mapObject in map)
            {
                if (mapObject == moveable) continue;
                if (!(mapObject is Tile tile)) continue;
                if (tile.IsPassable) continue;
                
                //Calculate intersection depth

                if (Intersects(moveableHitBox, tile.BoundingBox, direction, out var depth))
                {
                    moveable.IsIntersecting = true;
                    if (depth.Y != 0) moveable.IsTouchingGround = true;
                    
                    //If an intersection was found - adjust position
                    newPosition += depth;
                    moveableHitBox.X += depth.X;
                    moveableHitBox.Y += depth.Y;
                    Debug.WriteLine($"Depth: (${depth.X}, ${depth.Y})");
                    
                    //Adjust velocity based on intersection direction
                    if (direction == Direction.Horizontal)
                        moveable.Velocity = new Vector2(0, moveable.Velocity.Y);
                    else
                        moveable.Velocity = new Vector2(moveable.Velocity.X, 0);
                }
            }
            
            moveable.Position = direction == Direction.Horizontal
                ? new Vector2(newPosition.X, moveable.Position.Y)
                : new Vector2(moveable.Position.X, newPosition.Y);
        }
    }

    public enum Direction
    {
        Horizontal,
        Vertical
    }
}