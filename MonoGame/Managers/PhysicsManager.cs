﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoTest.GameObjects;
using MonoTest.GameObjects.Plants;
using MonoTest.Map.Tiles;
using Tile = MonoTest.Map.Tiles.Tile;

namespace MonoTest.Managers
{
    public class PhysicsManager
    {
        private const float Gravity = 600;
        private static Vector2 prevVelocity;
        private static Vector2 prevPosition;

        public void Move(Moveable moveable, float deltaTime, IEnumerable<GameObject> map)
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
            IEnumerable<GameObject> map)
        {
            var moveableBoundingBox = new RectangleF(moveable.BoundingBox.X * moveable.Scale + newPosition.X,
                moveable.BoundingBox.Y * moveable.Scale + newPosition.Y, moveable.BoundingBox.Width * moveable.Scale,
                moveable.BoundingBox.Height * moveable.Scale);


            foreach (var mapObject in map)
            {
                if (mapObject == moveable) continue;
                switch (mapObject)
                {
                    case Tile tile:
                    {
                        //if (Vector2.Distance(new Vector2(tile.BoundingBox.X,tile.BoundingBox.Y), moveable.Position) > 50) continue;
                        if (!Intersects(moveableBoundingBox, tile.BoundingBox, direction, out var depth)) continue;
                        if (tile.Type == TileType.DamageBlock) moveable.GetDamage(1, 0.35f);
                        if (tile.IsPassable) continue;
                        moveable.IsIntersecting = true;
                        if (depth.Y < 0) moveable.IsTouchingGround = true;

                        newPosition += depth;
                        moveableBoundingBox.X += depth.X;
                        moveableBoundingBox.Y += depth.Y;
                        //Debug.WriteLine($"Depth: (${depth.X}, ${depth.Y})");

                        moveable.Velocity = direction == Direction.Horizontal
                            ? new Vector2(0, moveable.Velocity.Y)
                            : new Vector2(moveable.Velocity.X, 0);
                        break;
                    }
                    case Plant plant:
                    {
                        if (moveable is Gorilla) continue;
                        foreach (var plantHitbox in plant.Animation.CurrentFrame.HitBoxes)
                        {
                            var plantHitboxX = plantHitbox.X + plant.Position.X;
                            var plantHitboxY = plantHitbox.Y + plant.Position.Y;

                            var updatedPlantHitbox = new RectangleF(plantHitboxX, plantHitboxY, plantHitbox.Width,
                                plantHitbox.Height);
                            plant.IsIntersecting = false;

                            if (moveable.CurrentAnimation.CurrentFrame.HitBoxes == null) continue;
                            foreach (var moveableHitbox in moveable.CurrentAnimation.CurrentFrame.HitBoxes)
                            {
                                var moveableHitboxX = moveableHitbox.X * moveable.Scale + moveable.Position.X;
                                var moveableHitboxY = moveableHitbox.Y * moveable.Scale + moveable.Position.Y;

                                var updatedMoveableHitbox = new RectangleF(moveableHitboxX, moveableHitboxY,
                                    moveableHitbox.Width * moveable.Scale, moveableHitbox.Height * moveable.Scale);

                                if (!plant.IsAttacking) continue;
                                if (!updatedMoveableHitbox.Intersects(updatedPlantHitbox)) continue;
                                if (moveable.IsInvulnerable) continue;
                                plant.IsIntersecting = true;
                                moveable.GetDamage(plant.Damage, 2);
                                moveable.Velocity = new Vector2(moveable.Velocity.X, -200);
                            }
                        }

                        break;
                    }
                    case Gorilla gorilla:
                        if (moveable is Gorilla) continue;
                        if (gorilla.Health <= 0) continue;
                            foreach (var gorillaHitbox in gorilla.CurrentAnimation.CurrentFrame.HitBoxes)
                        {
                            var gorillaHitboxX = gorillaHitbox.Position.X * moveable.Scale +  gorilla.Position.X;
                            var gorillaHitboxY = gorillaHitbox.Position.Y * moveable.Scale +  gorilla.Position.Y;

                            var updatedGorillaHitbox = new RectangleF(gorillaHitboxX, gorillaHitboxY, gorillaHitbox.Width * moveable.Scale, gorillaHitbox.Height * moveable.Scale);
                            
                            gorilla.IsIntersecting = false;
                            if (moveable.CurrentAnimation.CurrentFrame.AttackBoxes == null) continue;
                            foreach (var moveableAttackBox in moveable.CurrentAnimation.CurrentFrame.AttackBoxes)
                            {
                                var moveableAttackBoxX = moveableAttackBox.X * moveable.Scale + moveable.Position.X;
                                var moveableAttackBoxY = moveableAttackBox.Y * moveable.Scale + moveable.Position.Y;

                                var updatedMoveableAttackBox = new RectangleF(moveableAttackBoxX, moveableAttackBoxY, moveableAttackBox.Width * moveable.Scale, moveableAttackBox.Height * moveable.Scale);

                                if (updatedMoveableAttackBox.Intersects(updatedGorillaHitbox))
                                {
                                    if (moveable.IsInvulnerable) continue;
                                    gorilla.IsIntersecting = true;
                                    gorilla.GetDamage(moveable.Damage, 0.4f);
                                }
                            }
                        }

                        break;
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