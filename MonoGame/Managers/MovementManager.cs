using MonoTest.Input;

namespace MonoTest.Managers
{
    class MovementManager
    {
        public void Move(IMoveable moveable)
        {
            var direction = moveable.InputReader.ReadInput().Movement;
            if (moveable.InputReader.IsDestinationInput)
            {
                direction -= moveable.Position;
                direction.Normalize();
            }
            if (direction.X < 0) moveable.Direction = Direction.Left;
            if (direction.X > 0) moveable.Direction = Direction.Right;
            if (direction.X == 0) moveable.Direction = Direction.Idle;
            direction *= moveable.Speed;
            moveable.Position += direction;
        }
    }
}
