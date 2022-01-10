using System;
using Microsoft.Xna.Framework;
using MonoTest.GameObjects;
using MonoTest.Managers;
using MonoTest.Map.Tiles;

namespace MonoTest.Collisions
{
    internal class BasicTileCollision:ICollision
    {
        public void Collision(GameObject gameObject, GameObject collider, ref Vector2 newPosition, Direction direction)
        {
            var moveable = (Moveable)gameObject;
            var tile = (Tile)collider;
            
            var moveableBoundingBox = new RectangleF(moveable.BoundingBox.X * moveable.Scale + newPosition.X,
                moveable.BoundingBox.Y * moveable.Scale + newPosition.Y, moveable.BoundingBox.Width * moveable.Scale,
                moveable.BoundingBox.Height * moveable.Scale);
            
            if (!Intersects(moveableBoundingBox, tile.BoundingBox, direction, out var depth)) return;
            switch (tile.Type)
            {
                case TileType.FinishBlock when moveable is Hero hero:
                    hero.IsFinished = true;
                    break;
                case TileType.DamageBlock when moveable is Hero hero:
                    hero.GetDamage(1, 0.35f);
                    break;
                case TileType.Default:
                    break;
            }

            if (tile.IsPassable) return;
            moveable.IsIntersecting = true;
            if (depth.Y < 0) moveable.IsTouchingGround = true;

            newPosition += depth;
            moveableBoundingBox.X += depth.X;
            moveableBoundingBox.Y += depth.Y;
            //Debug.WriteLine($"Depth: (${depth.X}, ${depth.Y})");

            moveable.Velocity = direction == Direction.Horizontal
                ? new Vector2(0, moveable.Velocity.Y)
                : new Vector2(moveable.Velocity.X, 0);
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
    }
}