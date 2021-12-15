using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using MonoTest.GameObjects;
using MonoTest.Map.Tiles;

namespace MonoTest.Managers
{
    public class PhysicsManager
    {
        private const float Gravity = 350f;
        private static Vector2 prevVelocity;
        public void Move(Moveable moveable, float deltaTime, IEnumerable<IGameObject> map)
        {
    
            if(prevVelocity != moveable.Velocity){
                Debug.WriteLine($"Velocity Hero:  {moveable.Velocity}");
            }
            prevVelocity = moveable.Velocity;
            
            moveable.IsIntersecting = false;
            
            if(!moveable.IsTouchingGround) moveable.Velocity = new Vector2(moveable.Velocity.X, moveable.Velocity.Y + Gravity * deltaTime);
            var newPosition = moveable.Position + moveable.Velocity * new Vector2(deltaTime, deltaTime); 
            var moveableHitBox = moveable.CurrentAnimation.CurrentHitbox;
            moveableHitBox.X += (int)newPosition.X;
            moveableHitBox.Y += (int)newPosition.Y;

            moveable.IsTouchingGround = false;
            foreach (var mapObject in map)
            {
                if (mapObject == moveable) continue;
                if (!(mapObject is Tile { IsPassable: false } tile)) continue;
                var xIntersect = false;
                if (moveableHitBox.Intersects(tile.BoundingBox))
                {
                    xIntersect = true;
                    moveable.IsIntersecting = true;

                    if (moveableHitBox.Right >= tile.BoundingBox.Left || moveableHitBox.Left <= tile.BoundingBox.Right)
                    {
                        moveableHitBox.X =  (int)(moveableHitBox.X - newPosition.X + moveable.Position.X);
                    }
                }
                if (moveableHitBox.Intersects(tile.BoundingBox))
                {
                    xIntersect = false;
                    moveable.IsIntersecting = true;

                    if (moveableHitBox.Bottom >= tile.BoundingBox.Top)
                    {
                        if (moveable.Velocity.Y >= 0)
                        {
                            moveable.Velocity = new Vector2(moveable.Velocity.X, 0);
                            moveable.IsTouchingGround = true;
                            moveableHitBox.Y =  (int)(moveableHitBox.Y - newPosition.Y + moveable.Position.Y);
                            newPosition.Y = moveable.Position.Y;
                            if (moveableHitBox.Intersects(tile.BoundingBox))
                            {
                                moveable.Velocity = new Vector2(0, moveable.Velocity.Y);
                                newPosition.X = moveable.Position.X;
                            }
                        }
                    }
                }
                if(xIntersect)
                {
                    moveable.Velocity = new Vector2(0, moveable.Velocity.Y);
                    newPosition.X = moveable.Position.X;
                }
            }

            moveable.Position = newPosition;
        }
    }
}