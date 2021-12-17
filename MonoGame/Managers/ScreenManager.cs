using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Screens;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest.Managers
{
    public class ScreenManager
    {
        private IScreen _activeScreen;
        private IScreen _nextScreen;

        public void SetScreen(IScreen screen)
        {
            _nextScreen = screen;
        }
        public void SwitchScreen()
        {
            if (_nextScreen!=null)
            {
                _activeScreen = _nextScreen;
            }
            _nextScreen = null;
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
