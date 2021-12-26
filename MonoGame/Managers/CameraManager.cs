using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.GameObjects;
using MonoTest.Input;

namespace MonoTest.Managers
{
    public class CameraManager
    {
        private readonly Moveable _trackingObject;
        private Vector2 _cameraLocation;

        public CameraManager(Moveable trackingObject)
        {
            _trackingObject = trackingObject;
            _cameraLocation = trackingObject.Position;
        }

        public void Update(GraphicsDevice graphics)
        {
            var targetLocation = _trackingObject.Position;
            var distance = Vector2.Distance(_cameraLocation, targetLocation);
            const int maxVelocity = 6000; //6000
            const int minVelocity = 700; //700
            var velocity = distance > maxVelocity ? maxVelocity : distance;
            velocity = velocity < minVelocity ? minVelocity : velocity;
            var newLocation = Vector2.Lerp(_cameraLocation, targetLocation, velocity / maxVelocity);
            _cameraLocation = newLocation;
            Debug.WriteLine($"cameraLocation: {_cameraLocation}");
        }

        public Vector2 GetCameraPosition() => _cameraLocation;

        public void Draw(SpriteBatch spriteBatch,GraphicsDevice graphics)
        {
#if DEBUG
          Visualize(spriteBatch, graphics);
#endif
        }

        private void Visualize(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            const int cameraSize = 2;
            var rect = new Texture2D(graphics, cameraSize, cameraSize);
            var data = new Color[cameraSize * cameraSize];
            for (var i = 0; i < data.Length; ++i) data[i] = Color.Cyan;
            rect.SetData(data);
            var coo = new Vector2(_cameraLocation.X, _cameraLocation.Y);
            spriteBatch.Draw(rect, coo, Color.White);
        }
    }
}