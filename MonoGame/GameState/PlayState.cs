using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Components;
using MonoTest.GameObjects;
using MonoTest.Managers;
using MonoTest.Map.Tiles;

namespace MonoTest.GameState
{
    public class PlayState : IGameState
    {
        private readonly DisplayManager _displayManager;
        private readonly GameObjectManager _gameObjectManager;
        private readonly CameraManager _cameraManager;
        private readonly PhysicsManager _physicsManager;
        private readonly InputManager _inputManager;
        private readonly GraphicsDevice _graphicsDevice;
        private readonly int _chunkSize;
        private readonly int _blockSize;
        private List<int> _loadedChunks;
        private readonly ContentManager _contentManager;
        private readonly Hero _hero;
        private List<IComponent> _components;
        private HealthBar _healthBarHero;
        public event EventHandler OnDead;
        public event EventHandler OnFinish;


        public PlayState(
            DisplayManager displayManager,
            GameObjectManager gameObjectManager,
            CameraManager cameraManager,
            PhysicsManager physicsManager,
            InputManager inputManager,
            GraphicsDevice graphicsDevice,
            Hero hero,
            ContentManager contentManager,
            int chunkSize, int blockSize)
        {
            _displayManager = displayManager;
            _gameObjectManager = gameObjectManager;
            _cameraManager = cameraManager;
            _physicsManager = physicsManager;
            _inputManager = inputManager;
            _graphicsDevice = graphicsDevice;
            _hero = hero;
            _contentManager = contentManager;
            _chunkSize = chunkSize;
            _blockSize = blockSize;
            _loadedChunks = new List<int>();
            LoadUI();
        }

        private void LoadUI()
        {
            var texture = _contentManager.Load<Texture2D>("Components/healthBar");
            _healthBarHero = new HealthBar(texture,
                new Vector2(
                    _displayManager.GetMiddlePointScreen - ((texture.Width / 5) * (_hero.InitialHealth / 4)) / 2,
                    GraphicsDeviceManager.DefaultBackBufferHeight - 30), _hero, 1f);
            _components = new List<IComponent>();
            _gameObjectManager.GameObjects.ForEach(gameObject =>
            {
                if (gameObject is Moveable moveable)
                {
                    if (moveable is Hero) return;
                    _components.Add(new HealthBar(texture,
                        new Vector2(moveable.Position.X, moveable.Position.Y), moveable, 0.5f));
                }
            });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: CreateMatrix());
            _loadedChunks.ForEach(chunk =>
            {
                if (_gameObjectManager.ChunkedGameObjects[chunk] is not null)
                {
                    _gameObjectManager.ChunkedGameObjects[chunk]
                        .ForEach(gameObject => DrawGameObject(gameObject, spriteBatch));
                }
            });
            _gameObjectManager.GameObjects.ForEach(gameObject => DrawGameObject(gameObject, spriteBatch));
            _components.ForEach(c => { c.Draw(spriteBatch); });
            _cameraManager.Draw(spriteBatch, _graphicsDevice);
            spriteBatch.End();
            spriteBatch.Begin(transformMatrix: _displayManager.CalculateMatrix());
            _healthBarHero.Draw(spriteBatch);
            spriteBatch.End();
        }


        public void Update(GameTime gameTime)
        {
            ChunkLoader(_hero.Position.X);
            _components.ForEach(c => c.Update(gameTime, _displayManager.CalculateMatrix()));
            _cameraManager.Update(_graphicsDevice, gameTime);
            _inputManager.ProcessInput();
            _gameObjectManager.GameObjects.ForEach(g => UpdateGameObject(g, gameTime));
            _loadedChunks.ForEach(chunk =>
            {
                if (_gameObjectManager.ChunkedGameObjects[chunk] is not null)
                {
                    _gameObjectManager.ChunkedGameObjects[chunk]
                        .ForEach(gameObject => UpdateGameObject(gameObject, gameTime));
                }
            });
            _gameObjectManager.Moveables.ForEach(m =>
                _physicsManager.Move(m, (float)gameTime.ElapsedGameTime.TotalSeconds, _gameObjectManager.GameObjects.Concat(GetLoadedGameObjects())));
            _loadedChunks.ForEach(chunk =>
            {
                if (_gameObjectManager.ChunkedMoveables[chunk] is not null)
                {
                    _gameObjectManager.ChunkedMoveables[chunk]
                        .ForEach(m => _physicsManager.Move(m, (float)gameTime.ElapsedGameTime.TotalSeconds,
                            _gameObjectManager.GameObjects));
                }
            });

            if (_hero.Health <= 0 && _hero.CurrentAnimation.AnimationDoneFlag &&
                _hero.CurrentAction.Action == MoveableActionType.Dying)
            {
                OnDead?.Invoke(this, EventArgs.Empty);
            }

            if (_hero.IsFinished)
            {
                OnFinish.Invoke(this, EventArgs.Empty);
            }
        }

        private void DrawGameObject(GameObject gameObject, SpriteBatch spriteBatch)
        {
            gameObject?.Draw(spriteBatch, _graphicsDevice);
#if DEBUG
                if (gameObject is Tile tile)
                {
                    spriteBatch.DrawString(_contentManager.Load<SpriteFont>("Fonts/Font"),
                        $"X{tile.BoundingBox.X / tile.Size}\nY{tile.BoundingBox.Y / tile.Size}",
                        new Vector2(tile.BoundingBox.X + tile.Size / 2, tile.BoundingBox.Y), Color.Cyan, 0f,
                        Vector2.Zero, 0.3f, SpriteEffects.None, 0);

                    spriteBatch.DrawString(_contentManager.Load<SpriteFont>("Fonts/Font"),
                        $"{tile.BoundingBox.Y / tile.Size * _gameObjectManager.Width + tile.BoundingBox.X / tile.Size}",
                        new Vector2(tile.BoundingBox.X, tile.BoundingBox.Y), Color.Cyan, 0f, Vector2.Zero, 0.3f,
                        SpriteEffects.None, 0);
                }
#endif
        }

        private void UpdateGameObject(GameObject gameObject, GameTime gameTime)
        {
            if (gameObject.RemoveFlag)
            {
                _gameObjectManager.RemoveGameObject(gameObject);
            }

            gameObject?.Update(gameTime);
        }

        private void ChunkLoader(float x)
        {
            var currentChunk = (int)(x / _blockSize / _chunkSize);
            _loadedChunks = new List<int> { currentChunk };
            if (currentChunk != 0)
            {
                _loadedChunks.Add(currentChunk - 1);
            }

            _loadedChunks.Add(currentChunk + 1);
        }

        private List<GameObject> GetLoadedGameObjects() => _loadedChunks.SelectMany(chunk => _gameObjectManager.ChunkedGameObjects[chunk]).ToList();
        

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