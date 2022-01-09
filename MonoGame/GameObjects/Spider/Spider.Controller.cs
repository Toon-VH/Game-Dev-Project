using System;
using Microsoft.Xna.Framework;

namespace MonoTest.GameObjects
{
    public partial class Spider
    {
        private readonly Random _random = new Random();
        private int _currentSec = 0;
        private float _currentStateDuration = 3;
        


        private void Brains(GameTime gameTime)
        {
            if (Health <= 0) return;
            if (gameTime.TotalGameTime.Seconds == _currentSec) return;
            if (gameTime.TotalGameTime.Seconds % _currentStateDuration == 0)
            {
                var random = _random.Next(0, 500);
                switch (random)
                {
                    case < 120:
                        Velocity = Vector2.Zero;
                        CurrentAction = new MoveableAction(MoveableActionType.Idle, MoveableActionDirection.Static);
                        _currentStateDuration = 4;
                        break;
                    case < 500:
                        Velocity = _random.Next(0, 2) == 0 ? new Vector2(-60, 0) : new Vector2(60, 0);
                        CurrentAction = new MoveableAction(MoveableActionType.Running, Velocity.X > 0 ? MoveableActionDirection.Right : MoveableActionDirection.Left);
                        _currentStateDuration = 1.5f;
                        break;
                    default:
                        Velocity = Velocity;
                        break;
                }
            }

            _currentSec = gameTime.TotalGameTime.Seconds;
        }
    }
}