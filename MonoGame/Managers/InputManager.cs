using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using MonoTest.GameObjects;
using MonoTest.Input;

namespace MonoTest.Managers
{
    public class InputManager
    {
        private readonly IInputReader _inputReader;
        private readonly Moveable _moveable;
        private readonly SoundEffect _jumpSong;
        private MoveableActionDirection _prevDirection; 

        public InputManager(IInputReader inputReader, Moveable moveable, SoundEffect jumpSong)
        {
            _inputReader = inputReader;
            _moveable = moveable;
            _jumpSong = jumpSong;
            _prevDirection = MoveableActionDirection.Right;
        }

        public void ProcessInput()
        {
            if (_moveable is null) return;
            if(_moveable.CurrentAction.Action is MoveableActionType.Attacking or MoveableActionType.Rolling) return;

            var input = _inputReader?.ReadInput();
            if (input == null) return;

            _moveable.Velocity = input.MovementDirection.X switch
            {
                < 0 => new Vector2(-_moveable.Speed, _moveable.Velocity.Y),
                > 0 => new Vector2(_moveable.Speed, _moveable.Velocity.Y),
                0 => new Vector2(0, _moveable.Velocity.Y),
                _ => _moveable.Velocity
            };


            MoveableActionDirection direction;
            switch (_moveable.Velocity.X)
            {
                case < 0:
                    direction = MoveableActionDirection.Left;
                    break;
                case > 0:
                    direction = MoveableActionDirection.Right;
                    break;
                case 0:
                    direction = MoveableActionDirection.Static;
                    break;
                default:
                    direction = MoveableActionDirection.Static;
                    break;
            }
#if DEBUG
            Debug.WriteLine($"Velocity {_moveable.Velocity}");   
            Debug.WriteLine($"Direction {direction}");   
#endif

            if (input.Walking && input.MovementDirection.X != 0)
            {
                _moveable.CurrentAction = new MoveableAction(MoveableActionType.Running, direction);
            }
            
            if (input.Attack && _moveable.IsTouchingGround)
            {
                var effectiveDirection = direction != MoveableActionDirection.Static ? direction : _prevDirection;
                _moveable.CurrentAction = new MoveableAction(MoveableActionType.Attacking, effectiveDirection);
                if(_moveable.IsTouchingGround) _moveable.Velocity = Vector2.Zero;
            }

            if (input.Rol && _moveable.IsTouchingGround && direction != MoveableActionDirection.Static)
            {
                _moveable.Velocity = new Vector2(_moveable.Velocity.X * 1.3f, _moveable.Velocity.Y);
                _moveable.CurrentAction = new MoveableAction(MoveableActionType.Rolling, direction);
            }
            
            if (!input.Attack && !input.Rol && !input.Walking)
            {
                _moveable.CurrentAction = new MoveableAction(MoveableActionType.Idle, direction);
            }

            _prevDirection = direction switch
            {
                MoveableActionDirection.Right => MoveableActionDirection.Right,
                MoveableActionDirection.Left => MoveableActionDirection.Left,
                _ => _prevDirection
            };

            if (input.Jump && _moveable.IsTouchingGround)
            {
                _moveable.Velocity = new Vector2(_moveable.Velocity.X, -250);
                _moveable.IsTouchingGround = false;
                _jumpSong.Play();
            }
        }
    }
}