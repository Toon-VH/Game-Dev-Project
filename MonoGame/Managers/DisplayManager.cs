using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Microsoft.Xna.Framework.Graphics.GraphicsAdapter;

namespace MonoTest.Managers
{
    public class DisplayManager
    {
        private float _scaleX;
        private float _scaleY;

        public void InitializeDisplay(GraphicsDeviceManager graphics, int virtualWidth, int virtualHeight)
        {
            var actualWidth = DefaultAdapter.CurrentDisplayMode.Width;
            var actualHeight = DefaultAdapter.CurrentDisplayMode.Height;
            _scaleX = (float)actualWidth / virtualWidth;
            _scaleY = (float)actualHeight / virtualHeight;
            graphics.PreferredBackBufferWidth = actualWidth;
            graphics.PreferredBackBufferHeight = actualHeight;
            graphics.IsFullScreen = true;
            graphics.HardwareModeSwitch = false;
            graphics.ApplyChanges();
        }

        public float GetScaleX() => _scaleX;
        public float GetScaleY() => _scaleY;

        public Matrix CalculateMatrix()
        {
            return Matrix.CreateScale(_scaleX, _scaleY, 1.0f);
        }

        public int GetMiddlePointScreen => (int)(DefaultAdapter.CurrentDisplayMode.Width / 2 / GetScaleX());
    }
}