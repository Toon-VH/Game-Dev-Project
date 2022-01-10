using Microsoft.Xna.Framework;
using MonoTest.GameObjects;
using MonoTest.Managers;

namespace MonoTest.Collisions
{
    public interface ICollision
    {
        public void Collision(GameObject entity, GameObject collidingEntity, ref Vector2 newPosition, Direction direction);
    }
}