using System;
using Microsoft.Xna.Framework;
using MonoTest.GameObjects;
using MonoTest.GameObjects.Enemies;

namespace MonoTest.AI
{
    public class AggressiveBehavior : AIBehavior
    {
        private readonly Random _random = new();
        private int _currentSec = 0;
        private int _currentStateDuration = 3;

        public void Brains(GameTime gameTime, Enemy enemy)
        {

            if (enemy.Health <= 0) return;
            if (gameTime.TotalGameTime.Seconds == _currentSec) return;
            enemy.IsTaunting = false;
            if (gameTime.TotalGameTime.Seconds % _currentStateDuration == 0)
            {

                var random = _random.Next(0, 500);
                switch (random)
                {
                    case < 65:
                        enemy.Velocity = Vector2.Zero;
                        enemy.PlayScream();
                        enemy.IsTaunting = true;
                        enemy.CurrentAction = new MoveableAction(MoveableActionType.Taunting,
                            MoveableActionDirection.Static);
                        _currentStateDuration = 2;
                        break;
                    case < 500:
                        enemy.Velocity = _random.Next(0, 2) == 0 ? new Vector2(-60, 0) : new Vector2(60, 0);
                        var moveableActionType = MoveableActionType.AngryWalking;
                        enemy.CurrentAction = new MoveableAction(moveableActionType,
                            enemy.Velocity.X > 0 ? MoveableActionDirection.Right : MoveableActionDirection.Left);
                        _currentStateDuration = 1;
                        break;
                }
            }

            _currentSec = gameTime.TotalGameTime.Seconds;
        }
    }
}