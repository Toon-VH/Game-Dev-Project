using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.Managers
{
    public class DisplayManager
    {
        public void InitializeDisplay(GraphicsDeviceManager graphics )
        {
            int actualWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int actualHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            graphics.PreferredBackBufferWidth = actualWidth;
            graphics.PreferredBackBufferHeight = actualHeight;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }

        public Matrix CalculateMatrix()
        {
            var scaleX = (double) GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 384;
            var scaleY = (double) GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 240;
            return Matrix.CreateScale((float) scaleX, (float) scaleY, 1.0f);
        }
    }
    
}