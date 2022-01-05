using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoTest.GameObjects;
using MonoTest.GameObjects.Plants;
using MonoTest.Map.Tiles;

namespace MonoTest.Managers
{
    public class PhysicsManager
    {
        private const float Gravity = 570f;
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
            moveable.IsTouchingGround = false;

            moveable.Velocity = new Vector2(moveable.Velocity.X, moveable.Velocity.Y + Gravity * deltaTime);

            var newPosition = moveable.Position;

            newPosition += new Vector2(0, moveable.Velocity.Y * deltaTime);
            CheckCollisions(Direction.Vertical, moveable, newPosition, map);
            newPosition = moveable.Position;
            newPosition += new Vector2(moveable.Velocity.X * deltaTime, 0);
            CheckCollisions(Direction.Horizontal, moveable, newPosition, map);
        }

        private static bool Intersects(RectangleF player, RectangleF block, Direction direction, out Vector2 depth)
        {
            if (player.Intersects(block))
            {
                
                depth = direction == Direction.Vertical
                    ? new Vector2(0, GetVerticalIntersectionDepth(player, block))
                    : new Vector2(GetHorizontalIntersectionDepth(player, block), 0);
                return depth.Y != 0 || depth.X != 0;
            }

            depth = Vector2.Zero;
            return false;
        }

        private static float GetHorizontalIntersectionDepth(RectangleF rectA, RectangleF rectB)
        {
            var halfWidthA = rectA.Width / 2.0f;
            var halfWidthB = rectB.Width / 2.0f;

            var centerA = rectA.Left + halfWidthA;
            var centerB = rectB.Left + halfWidthB;

            var distanceX = centerA - centerB;
            var minDistanceX = halfWidthA + halfWidthB;

            if (Math.Abs(distanceX) >= minDistanceX)
                return 0f;

            return distanceX > 0 ? minDistanceX - distanceX : -minDistanceX - distanceX;
        }

        private static float GetVerticalIntersectionDepth(RectangleF rectA, RectangleF rectB)
        {
            var halfHeightA = rectA.Height / 2.0f;
            var halfHeightB = rectB.Height / 2.0f;

            var centerA = rectA.Top + halfHeightA;
            var centerB = rectB.Top + halfHeightB;

            var distanceY = centerA - centerB;
            var minDistanceY = halfHeightA + halfHeightB;

            if (Math.Abs(distanceY) >= minDistanceY)
                return 0f;

            return distanceY > 0 ? minDistanceY - distanceY : -minDistanceY - distanceY;
        }

        private static void CheckCollisions(Direction direction, Moveable moveable, Vector2 newPosition,
            IEnumerable<IGameObject> map)
        {
            var moveableHitBox = moveable.BoundingBox;
            moveableHitBox.X += newPosition.X;
            moveableHitBox.Y += newPosition.Y;

            foreach (var mapObject in map)
            {
                if (mapObject == moveable) continue;
                switch (mapObject)
                {
                    case Tile tile:
                    {
                        //if (Vector2.Distance(new Vector2(tile.BoundingBox.X,tile.BoundingBox.Y), moveable.Position) > 50) continue;
                        if (!Intersects(moveableHitBox, tile.BoundingBox, direction, out var depth)) continue;
                        if (tile.Type == TileType.DamageBlock) moveable.GetDamage(1,0.35f);
                        if (tile.IsPassable) continue;
                        moveable.IsIntersecting = true;
                        if (depth.Y < 0) moveable.IsTouchingGround = true;

                        newPosition += depth;
                        moveableHitBox.X += depth.X;
                        moveableHitBox.Y += depth.Y;
                        //Debug.WriteLine($"Depth: (${depth.X}, ${depth.Y})");

                        moveable.Velocity = direction == Direction.Horizontal
                            ? new Vector2(0, moveable.Velocity.Y)
                            : new Vector2(moveable.Velocity.X, 0);
                        break;
                    }
                    case Plant plant:
                    {
                        if (moveable is Gorilla) continue;
                        var sourceRectangle = plant.Animation.CurrentFrame.SourceRectangle;
                        var hitboxX = plant.Animation.CurrentHitbox.X + plant.Position.X - sourceRectangle.Width / 2;
                        var hitboxY = plant.Animation.CurrentHitbox.Y + plant.Position.Y - sourceRectangle.Height / 2;

                        var rect = new RectangleF((int)hitboxX, (int)hitboxY, plant.Animation.CurrentHitbox.Width,
                            plant.Animation.CurrentHitbox.Height);
                        plant.IsIntersecting = false;
                        
                        if (moveableHitBox.Intersects(rect))
                        {
                            if (plant.Attack)
                            {
                                plant.IsIntersecting = true;
                                moveable.GetDamage(plant.Damage,2);
                                moveable.Velocity = new Vector2(moveable.Velocity.X, -200); 
                            }
                        }
                        break;
                    }
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