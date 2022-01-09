using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Components;
using MonoTest.GameObjects;
using MonoTest.Managers;
using MonoTest.Map.Tiles;

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
        private readonly ContentManager _contentManager;
        private readonly Hero _hero;
        private List<Component> _components;
        private HealthBar _healtBarHero;
        public event EventHandler OnDead;
        public event EventHandler OnFinish;


        public GameScreen(
            DisplayManager displayManager,
            GameObjectManager gameObjectManager,
            CameraManager cameraManager,
            PhysicsManager physicsManager,
            InputManager inputManager,
            GraphicsDevice graphicsDevice,
            Hero hero,
            ContentManager contentManager)
        {
            _displayManager = displayManager;
            _gameObjectManager = gameObjectManager;
            _cameraManager = cameraManager;
            _physicsManager = physicsManager;
            _inputManager = inputManager;
            _graphicsDevice = graphicsDevice;
            _hero = hero;
            _contentManager = contentManager;
            LoadUI();
        }

        private void LoadUI()
        {
            var texture = _contentManager.Load<Texture2D>("Components/healthBar");
             _healtBarHero = new HealthBar(texture, new Vector2(_displayManager.GetMiddlePointScreen - ((texture.Width / 5) * (_hero.InitialHealth / 4)) / 2, GraphicsDeviceManager.DefaultBackBufferHeight - 30), _hero, 1f);
             _components = new List<Component>();
             _gameObjectManager.GameObjects.ForEach(gameObject =>
            {
                if (gameObject is Moveable moveable)
                {
                    if (moveable is Hero) return;
                    _components.Add(new HealthBar(texture,
                        new Vector2(moveable.Position.X, moveable.Position.Y ), moveable, 0.5f));
                }
            });
        }

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: CreateMatrix());
            _components.ForEach(c =>
            {
                c.Draw(spriteBatch);
            });
            
            _gameObjectManager.GameObjects.ForEach(gameObject =>
            {
                gameObject?.Draw(spriteBatch, _graphicsDevice);
// #if DEBUG
//                 if (gameObject is Tile tile)
//                 {
//                     spriteBatch.DrawString(_contentManager.Load<SpriteFont>("Fonts/Font"),
//                         $"X{tile.BoundingBox.X / tile.Size}\nY{tile.BoundingBox.Y / tile.Size}",
//                         new Vector2(tile.BoundingBox.X + tile.Size/2, tile.BoundingBox.Y+ tile.Size/2), Color.Cyan,0f,Vector2.Zero, 0.3f,SpriteEffects.None,0);
//                 }
// #endif
            });
            
            _cameraManager.Draw(spriteBatch, _graphicsDevice);
            spriteBatch.End();
            spriteBatch.Begin(transformMatrix: _displayManager.CalculateMatrix());
            _healtBarHero.Draw(spriteBatch);
            spriteBatch.End();
            
        }

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        public void Update(GameTime gameTime)
        {
            _components.ForEach(c => c.Update(gameTime, _displayManager.CalculateMatrix()));
            _cameraManager.Update(_graphicsDevice, gameTime);
            _inputManager.ProcessInput();
            _gameObjectManager.GameObjects.ForEach(g =>
            {
                if (g.RemoveFlag)
                {
                    _gameObjectManager.RemoveGameObject(g);
                }

                g?.Update(gameTime);
            });
            _gameObjectManager.Moveables.ForEach(m =>
                _physicsManager.Move(m, (float)gameTime.ElapsedGameTime.TotalSeconds, _gameObjectManager.GameObjects));

            if (_hero.Health <= 0 && _hero.CurrentAnimation.AnimationDoneFlag && _hero.CurrentAction.Action == MoveableActionType.Dying)
            {
                OnDead?.Invoke(this, EventArgs.Empty);
            }
            if (_hero.IsFinished) OnFinish.Invoke(this, EventArgs.Empty);
        }
        
        private Matrix CreateMatrix()
        {
            return _displayManager.CalculateMatrix() * Matrix.CreateTranslation(
                new Vector3(
                    (int)(-_cameraManager.GetCameraPosition().X * _displayManager.GetScaleX() +
                          (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2),
                    0, //(int)(-_cameraManager.GetCameraPosition().Y * _displayManager.GetScaleY() + (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2)
                    0));
        }
    }
}