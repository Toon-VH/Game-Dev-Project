using Microsoft.Xna.Framework;
using MonoTest.GameObjects;
using MonoTest.GameObjects.Plants;
using MonoTest.Managers;

namespace MonoTest.Collisions
{
    public class HeroPlantCollision : ICollision
    {
        public void Collision(GameObject entity, GameObject collidingEntity, ref Vector2 newPosition,
            Direction direction)
        {
            var moveable = (Hero)entity;
            var plant = (Plant)collidingEntity;
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
        }
    }
}