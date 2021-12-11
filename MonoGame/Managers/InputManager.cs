using Microsoft.Xna.Framework;
using MonoTest.GameObjects;
using MonoTest.Input;

namespace MonoTest.Managers
{
    public class InputManager
    {
        private readonly IInputReader _inputReader;
        private readonly Moveable _moveable;

        public InputManager(IInputReader inputReader, Moveable moveable)
        {
            _inputReader = inputReader;
            _moveable = moveable;
        }

        public void ProcessInput()
        { 
            if (_moveable is null) return;
            var input = _inputReader?.ReadInput();
            if (input != null)
            {
                if (_inputReader.IsDestinationInput)
                {
                    input.MovementDirection -= _moveable.Position;
                    input.MovementDirection.Normalize();
                }

                if (input.MovementDirection.X < 0) _moveable.Velocity = new Vector2(-80, _moveable.Velocity.Y);
                if (input.MovementDirection.X > 0) _moveable.Velocity = new Vector2(80, _moveable.Velocity.Y);
                if (input.MovementDirection.X == 0) _moveable.Velocity = new Vector2(0, _moveable.Velocity.Y);
                if (input.Jump && _moveable.IsTouchingGround)
                {
                    _moveable.Velocity = new Vector2(_moveable.Velocity.X, -150);
                    _moveable.IsTouchingGround = false;
                }
            }
            
        }
    }
}