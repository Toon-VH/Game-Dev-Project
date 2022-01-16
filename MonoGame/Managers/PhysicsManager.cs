using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoTest.Collisions;
using MonoTest.GameObjects;

namespace MonoTest.Managers
{
    public class PhysicsManager
    {
        private const float Gravity = 600;
        private IDictionary<(Type, Type), ICollision> _collisions = new Dictionary<(Type, Type), ICollision>();

        
        public void Move(Moveable moveable, float deltaTime, IEnumerable<GameObject> map)
        {
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


        private void CheckCollisions(Direction direction, Moveable moveable, Vector2 newPosition,
            IEnumerable<GameObject> gameObjects)
        {
            
            
            foreach (var gameObject in gameObjects)
            {
                if (gameObject == moveable) continue;
                var collisionKey = (moveable.GetType(), gameObject.GetType());
                if (!_collisions.ContainsKey(collisionKey)) continue;
                _collisions[collisionKey].Collision(moveable, gameObject, ref newPosition, direction);
            }

            moveable.Position = direction == Direction.Horizontal
                ? new Vector2(newPosition.X, moveable.Position.Y)
                : new Vector2(moveable.Position.X, newPosition.Y);
        }
        
        public void AddCollision(Type gameObjectType, Type colliderType, ICollision collision)
        {
            _collisions.Add((gameObjectType, colliderType), collision);
        }
    }

    public enum Direction
    {
        Horizontal,
        Vertical
    }
}