using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoTest.GameObjects;
using MonoTest.Input;
using MonoTest.Managers;
using MonoTest.Map;

namespace MonoTest
{
    public class GameEngine : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private readonly MapGenerator _mapGenerator;
        private readonly DisplayManager _displayManager;
        private SpriteBatch _spriteBatch;

        private Texture2D _heroTexture;
        private Texture2D _backGroundTexture;
        private Texture2D _middleGroundTexture;
        private Texture2D _tiles;
        private Hero _hero;
        private Background _background;
        private readonly GameObjectManager _gameObjectManager;

        private CameraManager _cameraManager;

        public GameEngine()
        {
            _graphics = new GraphicsDeviceManager(this);
            _gameObjectManager = new GameObjectManager();
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
            _hero = new Hero(_heroTexture, new KeyboardReader());
            _mapGenerator.InitializeBlocks(_tiles, _gameObjectManager.GameObjects.ToList());
            _gameObjectManager.AddGameObject(_hero);
            _background = new Background(_backGroundTexture, _middleGroundTexture);
            _cameraManager = new CameraManager(_hero, 25);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _heroTexture = Content.Load<Texture2D>("Archaeologist Sprite Sheet");
            _backGroundTexture = Content.Load<Texture2D>("background");
            _middleGroundTexture = Content.Load<Texture2D>("middleground");
            _tiles = Content.Load<Texture2D>("tileset");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            _hero.Update(gameTime);
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
            _gameObjectManager.GameObjects.ForEach(gameObject =>
            {
                if (gameObject != null)
                {
                    gameObject.Draw(_spriteBatch, GraphicsDevice);
                }
            });
            _cameraManager.Update(_spriteBatch, _graphics.GraphicsDevice);
            _spriteBatch.End();
            base.Draw(gameTime);
        }


        private void Collision()
        {
            // foreach (Block block in blocks) 
            // {
            //     if (Hero.GetBoundingBox().Intersects(block.BoundingBox);
            //     {
            //         if (block.IsPassable)
            //         {
            //             PushPlayerBack();
            //         }
            //     }
            // }
        }

        private void PushPlayerBack()
        {
            throw new NotImplementedException();
        }

        private Matrix CreateMatrix()
        {
            return _displayManager.CalculateMatrix() * Matrix.CreateTranslation(new Vector3(
                (-_cameraManager.GetCameraPosition().X * _displayManager.GetScaleX()) +
                ((float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2), 0, 0));
        }
    }
}