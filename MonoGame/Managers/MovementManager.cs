using Microsoft.Xna.Framework;
using MonoTest.Input;

namespace MonoTest.Managers
{
    class MovementManager
    {
        public void Move(Moveable moveable)
        {
            var input = moveable.InputReader?.ReadInput();
            if (input != null)
            {
                if (moveable.InputReader.IsDestinationInput)
                {
                    input.Movement -= moveable.Position;
                    input.Movement.Normalize();
                }

                if (input.Movement.X < 0) moveable.Direction = new Vector2(-1,0);
                if (input.Movement.X > 0) moveable.Direction = new Vector2(1,0);
                if (input.Movement.X == 0) moveable.Direction = new Vector2(0,0);
                input.Movement *= moveable.Speed;
            }
            var newPosition = moveable.Position + input?.Movement ?? moveable.Direction;

            if (newPosition.X < 0) newPosition.X = moveable.Position.X;
            moveable.Position = newPosition;
        }
    }
}
