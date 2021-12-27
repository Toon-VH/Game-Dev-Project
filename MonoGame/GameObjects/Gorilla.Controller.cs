using System;
using Microsoft.Xna.Framework;

namespace MonoTest.GameObjects
{
    public partial class Gorilla
    {
        private readonly Random _random = new Random();
        private int _currentSec = 0;
        private int _currentStateDuration = 3;

        private void Brains(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Seconds == _currentSec) return;
            _poundingChest = false;
            if (gameTime.TotalGameTime.Seconds % _currentStateDuration == 0)
            {
                var random = _random.Next(0, 500);
                switch (random)
                {
                    case < 50:
                        Velocity = Vector2.Zero;
                        _currentStateDuration = 4;
                        break;
                    case < 200:
                        Velocity = Vector2.Zero;
                        _roar.Play();
                        _poundingChest = true;
                        _currentStateDuration = 4;
                        break;
                    case < 500:
                        Velocity = _random.Next(0, 2) == 0 ? new Vector2(-60, 0) : new Vector2(60, 0);
                        _currentStateDuration = 3;
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