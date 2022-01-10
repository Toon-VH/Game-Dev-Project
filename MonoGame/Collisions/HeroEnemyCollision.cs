using Microsoft.Xna.Framework;
using MonoTest.GameObjects;
using MonoTest.Managers;

namespace MonoTest.Collisions
{
    public class HeroEnemyCollision : ICollision
    {
        public void Collision(GameObject entity, GameObject collidingEntity, ref Vector2 newPosition,
            Direction direction)
        {
            var moveable = (Hero)entity;
            var otherMoveable = (Moveable)collidingEntity;
            if (moveable == otherMoveable) return;
            if (otherMoveable.Health <= 0) return;
            
            if (otherMoveable.CurrentAnimation.CurrentFrame.HitBoxes == null) return;
            foreach (var otherMoveAbleHitbox in otherMoveable.CurrentAnimation.CurrentFrame.HitBoxes)
            {
                var updatedOtherMoveableHitbox = UpdateBox(otherMoveAbleHitbox, otherMoveable);

                otherMoveable.IsIntersecting = false;
                if (moveable.CurrentAnimation.CurrentFrame.AttackBoxes == null) continue;
                foreach (var moveableAttackBox in moveable.CurrentAnimation.CurrentFrame.AttackBoxes)
                {
                    var updatedMoveableAttackBox = UpdateBox(moveableAttackBox, moveable);

                    if (updatedMoveableAttackBox.Intersects(updatedOtherMoveableHitbox))
                    {
                        if (otherMoveable.IsInvulnerable) continue;
                        otherMoveable.IsIntersecting = true;
                        otherMoveable.GetDamage(moveable.Damage, 0.8f);
                    }
                }
            }

            if (moveable.CurrentAnimation.CurrentFrame.HitBoxes == null) return;
            foreach (var moveableHitbox in moveable.CurrentAnimation.CurrentFrame.HitBoxes)
            {
                var updatedMoveableHitbox = UpdateBox(moveableHitbox, moveable);

                otherMoveable.IsIntersecting = false;
                if (otherMoveable.CurrentAnimation.CurrentFrame.AttackBoxes == null) continue;
                foreach (var otherMoveableAttackBox in otherMoveable.CurrentAnimation.CurrentFrame
                             .AttackBoxes)
                {
                    var updatedOtherMoveableAttackBox = UpdateBox(otherMoveableAttackBox, otherMoveable);

                    if (updatedOtherMoveableAttackBox.Intersects(updatedMoveableHitbox))
                    {
                        if (moveable.IsInvulnerable) continue;
                        otherMoveable.IsIntersecting = true;
                        moveable.GetDamage(otherMoveable.Damage, 1.5f);
                    }
                }
            }
        }

        private static RectangleF UpdateBox(RectangleF rectangle, Moveable moveable)
        {
            var updatedX = rectangle.X * moveable.Scale + moveable.Position.X;
            var updatedY = rectangle.Y * moveable.Scale + moveable.Position.Y;

            return new RectangleF(updatedX, updatedY, rectangle.Width * moveable.Scale,
                rectangle.Height * moveable.Scale);
        }
    }
}