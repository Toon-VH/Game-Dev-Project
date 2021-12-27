using System;
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
        public int MaxVelocity { get; set; } = 30;
        public int MinVelocity { get; set; } = 10;
        public int FadePoint { get; set; } = 50;
        public bool Cinematic { get; set; } = false;
        public int CinematicVelocity = 3000;
        public event EventHandler OnExitCinematic;
        private readonly GraphicsDeviceManager _graphicsDeviceManager;
        private readonly DisplayManager _displayManager;


        public CameraManager(Moveable trackingObject, GraphicsDeviceManager graphicsDeviceManager,
            DisplayManager displayManager)
        {
            _trackingObject = trackingObject;
            _graphicsDeviceManager = graphicsDeviceManager;
            _displayManager = displayManager;
            _cameraLocation = trackingObject.Position;
        }

        public void Update(GraphicsDevice graphics, GameTime gameTime)
        {
            Vector2 newLocation;
            var targetLocation = new Vector2(_trackingObject.Position.X + _trackingObject.CurrentAnimation.CurrentFrame.SourceRectangle.Width,_trackingObject.Position.Y+ _trackingObject.CurrentAnimation.CurrentFrame.SourceRectangle.Height);
            if (!Cinematic)
            {
                var distanceToTargetLocation = Vector2.Distance(_cameraLocation, targetLocation);
                float velocity = MaxVelocity;

                if (distanceToTargetLocation < FadePoint)
                {
                    velocity = distanceToTargetLocation / FadePoint * MaxVelocity;
                }

                if (velocity < MinVelocity) velocity = MinVelocity;
                newLocation = Vector2.Lerp(_cameraLocation, targetLocation,
                    velocity * gameTime.ElapsedGameTime.Milliseconds / 1000);
                _cameraLocation = newLocation;
            }
            else
            {
                newLocation = new Vector2(_cameraLocation.X, targetLocation.Y);
                var signedDistance = _cameraLocation.X - targetLocation.X;
                if (signedDistance > 0)
                {
                    newLocation.X -= (float)CinematicVelocity * gameTime.ElapsedGameTime.Milliseconds / 1000;
                    if (newLocation.X <= targetLocation.X)
                    {
                        newLocation.X = targetLocation.X;
                        Cinematic = false;
                        OnExitCinematic?.Invoke(this, EventArgs.Empty);
                    }
                }

                if (signedDistance < 0)
                {
                    newLocation.X += (float)CinematicVelocity * gameTime.ElapsedGameTime.Milliseconds / 1000;
                    if (newLocation.X >= targetLocation.X)
                    {
                        newLocation.X = targetLocation.X;
                        Cinematic = false;
                        OnExitCinematic?.Invoke(this, EventArgs.Empty);
                    }
                }

                if (signedDistance == 0)
                {
                    Cinematic = false;
                    OnExitCinematic?.Invoke(this, EventArgs.Empty);
                }
            }

            if (newLocation.X < _displayManager.GetMiddlePointScreen)
                newLocation.X = _displayManager.GetMiddlePointScreen;
            _cameraLocation = newLocation;
        }

        public Vector2 GetCameraPosition() => _cameraLocation;

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics)
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