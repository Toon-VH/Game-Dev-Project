using Microsoft.Xna.Framework;
using MonoTest.GameObjects.Enemies;

namespace MonoTest.AI
{
    public interface AIBehavior
    {
        void Brains(GameTime gameTime, Enemy enemy);
    }
}