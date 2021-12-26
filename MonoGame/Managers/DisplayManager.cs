using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.Managers
{
    public class DisplayManager
    {
        private float _scaleX;
        private float _scaleY;

        public void InitializeDisplay(GraphicsDeviceManager graphics, int virtualWidth, int virtualHeight)
        {
            var actualWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            var actualHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _scaleX = (float)actualWidth / virtualWidth;
            _scaleY = (float)actualHeight / virtualHeight;
            graphics.PreferredBackBufferWidth = actualWidth;
            graphics.PreferredBackBufferHeight = actualHeight;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }

        public float GetScaleX() => _scaleX;
        public float GetScaleY() => _scaleY;

        public Matrix CalculateMatrix()
        {
            return Matrix.CreateScale(_scaleX, _scaleY, 1.0f);
        }

        public int GetMiddlePointScreen =>
            (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 / GetScaleX());
    }
}