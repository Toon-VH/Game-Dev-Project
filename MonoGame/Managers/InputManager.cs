using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using MonoTest.Animations;
using MonoTest.GameObjects;
using MonoTest.Input;

namespace MonoTest.Managers
{
    public class InputManager
    {
        private readonly IInputReader _inputReader;
        private readonly Moveable _moveable;
        private readonly SoundEffect _jumpSong;

        public InputManager(IInputReader inputReader, Moveable moveable, SoundEffect jumpSong)
        {
            _inputReader = inputReader;
            _moveable = moveable;
            _jumpSong = jumpSong;
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

                if (_moveable is Hero hero)
                {
                    if (input.Attack)
                    {
                        hero.Action(Actions.Attack);
                    }

                    if (input.Rol)
                    {
                        hero.Action(Actions.Rol);
                    }
                }

                if (input.MovementDirection.X < 0)
                    _moveable.Velocity = new Vector2(-_moveable.Speed, _moveable.Velocity.Y);
                if (input.MovementDirection.X > 0)
                    _moveable.Velocity = new Vector2(_moveable.Speed, _moveable.Velocity.Y);
                if (input.MovementDirection.X == 0) _moveable.Velocity = new Vector2(0, _moveable.Velocity.Y);

                if (input.Jump && _moveable.IsTouchingGround)
                {
                    _moveable.Velocity = new Vector2(_moveable.Velocity.X, -500);
                    _moveable.IsTouchingGround = false;
                    _jumpSong.Play();
                }
            }
        }
    }
}