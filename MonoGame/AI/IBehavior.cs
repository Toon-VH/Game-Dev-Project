using System;
using Microsoft.Xna.Framework;
using MonoTest.GameObjects.Enemies;

namespace MonoTest.AI
{
    public interface IBehavior
    {
        void Brains(GameTime gameTime, Enemy enemy);
    }
}