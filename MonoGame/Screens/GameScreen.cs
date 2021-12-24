﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Components;
using MonoTest.GameObjects;
using MonoTest.Managers;

namespace MonoTest.Screens
{
    public class GameScreen : IScreen
    {
        private readonly DisplayManager _displayManager;
        private readonly GameObjectManager _gameObjectManager;
        private readonly CameraManager _cameraManager;
        private readonly PhysicsManager _physicsManager;
        private readonly InputManager _inputManager;
        private readonly GraphicsDevice _graphicsDevice;
        private readonly Hero _hero;

        public GameScreen(
            DisplayManager displayManager,
            GameObjectManager gameObjectManager,
            CameraManager cameraManager,
            PhysicsManager physicsManager,
            InputManager inputManager,
            GraphicsDevice graphicsDevice,
            Hero hero)
        {
            _displayManager = displayManager;
            _gameObjectManager = gameObjectManager;
            _cameraManager = cameraManager;
            _physicsManager = physicsManager;
            _inputManager = inputManager;
            _graphicsDevice = graphicsDevice;
            _hero = hero;
        }
        
        private void LoadUI()
        {
            // var startButton = new Button(_contentManager.Load<Texture2D>("Button (1)"), _contentManager.Load<SpriteFont>("Font"))
            // {
            //     Position = new Vector2(133, 100),
            //     Text = "start",
            //     PenColor = Color.CornflowerBlue
            // };
            // startButton.Click += StartButton_Click;
            //
            // _buttons = new List<Component>()
            // {
            //     startButton,
            //     quitButton
            // };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: CreateMatrix());
            _gameObjectManager.GameObjects.ForEach(gameObject => gameObject?.Draw(spriteBatch, _graphicsDevice));
            _cameraManager.Update(spriteBatch, _graphicsDevice);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            _inputManager.ProcessInput();
            _gameObjectManager.GameObjects.ForEach(g => g?.Update(gameTime));
            _gameObjectManager.Moveables.ForEach(m => _physicsManager.Move(m, (float)gameTime.ElapsedGameTime.TotalSeconds, _gameObjectManager.GameObjects));
        }

        private void DrawHealth(SpriteBatch spriteBatch)
        {
            
        }
        
        private Matrix CreateMatrix()
        {
            return _displayManager.CalculateMatrix() * Matrix.CreateTranslation(
                new Vector3(
                    -_cameraManager.GetCameraPosition().X * _displayManager.GetScaleX()
                    + (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2, 0, 0));
        }
    }
}