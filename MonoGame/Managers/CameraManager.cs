using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Input;

namespace MonoTest.Managers
{
    public class CameraManager
    {
        private readonly Moveable _trackingObject;
        private Vector2 _cameraLocation;
        private readonly float _deltaX;
        private readonly float _deltaY;
        
        public CameraManager(Moveable trackingObject, float deltaX = 0, float deltaY = 0)
        {
            _trackingObject = trackingObject;
            _deltaX = deltaX;
            _deltaY = deltaY;
            _cameraLocation = trackingObject.Position;
            _cameraLocation.X += deltaX;
            _cameraLocation.Y += deltaY;
        }
        
        public void Update(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            var targetLocation = _trackingObject.Position;
            targetLocation.X += _deltaX;
            targetLocation.Y += _deltaY; 
            var distance = Vector2.Distance(_cameraLocation, targetLocation);
            var maxVelocity = 1;
            var minVelocity = 1;
            var velocity = distance > maxVelocity ? maxVelocity : distance;
            velocity = velocity < minVelocity ? minVelocity : velocity;
            
            var newLocation = Vector2.Lerp(_cameraLocation, targetLocation,velocity/maxVelocity);
            _cameraLocation = newLocation;
            
            // Visualize(spriteBatch, graphics);
        }

        public Vector2 GetCameraPosition() => _cameraLocation;

        private void Visualize(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            var rect = new Texture2D(graphics, 5, 5);
            var data = new Color[5 * 5];
            for (var i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            rect.SetData(data);
            spriteBatch.Draw(rect, _cameraLocation, Color.White);
        }
    }
}