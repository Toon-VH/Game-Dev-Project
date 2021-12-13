using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonoTest.GameObjects;
using MonoTest.Input;
using MonoTest.Managers;
using MonoTest.Map;

namespace MonoTest
{
    public class GameEngine : Game
    {
        private Background _background;
        private Hero _hero;
        private SpriteBatch _spriteBatch;
        private Texture2D _backGroundTexture;
        private Texture2D _heroTexture;
        private Texture2D _middleGroundTexture;
        private Texture2D _tiles;
        private readonly DisplayManager _displayManager;
        private readonly GameObjectManager _gameObjectManager;
        private readonly GraphicsDeviceManager _graphics;
        private readonly MapGenerator _mapGenerator;
        private readonly PhysicsManager _physicsManager;
        private InputManager _inputManager;

        private CameraManager _cameraManager;
        private SoundEffect _jumpSong;

        public GameEngine()
        {
            _graphics = new GraphicsDeviceManager(this);
            _gameObjectManager = new GameObjectManager();
            _physicsManager = new PhysicsManager();
            _mapGenerator = new MapGenerator(Maps.map1, 12);
            _displayManager = new DisplayManager();
            Window.Title = "Best Game Ever";
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
            _displayManager.InitializeDisplay(_graphics, 384, 240);
            _hero = new Hero(_heroTexture);
            _mapGenerator.InitializeBlocks(_tiles, _gameObjectManager);
            _gameObjectManager.AddGameObject(_hero);
            _inputManager = new InputManager(new KeyboardReader(), _hero, _jumpSong);
            _background = new Background(_backGroundTexture, _middleGroundTexture);
            _cameraManager = new CameraManager(_hero);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _heroTexture = Content.Load<Texture2D>("Archaeologist Sprite Sheet");
            _backGroundTexture = Content.Load<Texture2D>("background");
            _middleGroundTexture = Content.Load<Texture2D>("middleground");
            _tiles = Content.Load<Texture2D>("tileset");
            _jumpSong = Content.Load<SoundEffect>("jump");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            _inputManager.ProcessInput();
            _hero.Update(gameTime);
            _gameObjectManager.Moveables.ForEach(m =>
            {
                _physicsManager.Move(m, (float)gameTime.ElapsedGameTime.TotalSeconds,
                    _gameObjectManager.GameObjects);
            });
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp,
                transformMatrix: _displayManager.CalculateMatrix());

            _background.Draw(_spriteBatch);
            _spriteBatch.End();

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: CreateMatrix());
            _gameObjectManager.GameObjects.ForEach(gameObject => gameObject?.Draw(_spriteBatch, GraphicsDevice));
            _cameraManager.Update(_spriteBatch, _graphics.GraphicsDevice);
            _spriteBatch.End();
            base.Draw(gameTime);
        }


        private Matrix CreateMatrix()
        {
            return _displayManager.CalculateMatrix() * Matrix.CreateTranslation(new Vector3(
                (-_cameraManager.GetCameraPosition().X * _displayManager.GetScaleX()) +
                ((float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2), 0, 0));
        }
    }
}