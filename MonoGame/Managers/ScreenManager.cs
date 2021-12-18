using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Screens;
namespace MonoTest.Managers
{
    public class ScreenManager
    {
        private IScreen _activeScreen;

        public void SetScreen(IScreen screen)
        {
            _activeScreen = screen;
        }

        internal void Update(GameTime gameTime)
        {
            _activeScreen.Update(gameTime);
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            _activeScreen.Draw(spriteBatch);
        }
    }
}