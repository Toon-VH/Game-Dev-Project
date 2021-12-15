using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoTest.Controls;
using MonoTest.GameObjects;
using MonoTest.Input;
using MonoTest.Managers;
using MonoTest.Map;
using MonoTest.Screens;

namespace MonoTest
{
    public class GameEngine : Game
    {
        public static Background _background;
        public static Hero _hero;
        private SpriteBatch _spriteBatch;
        private Texture2D _backGroundTexture;
        private Texture2D _heroTexture;
        private Texture2D _middleGroundTexture;
        private Texture2D _tiles;
        public static DisplayManager _displayManager;
        public static GameObjectManager _gameObjectManager;
        public static GraphicsDeviceManager _graphics;
        private readonly MapGenerator _mapGenerator;
        public static PhysicsManager _physicsManager;
        public static InputManager _inputManager;

        public static CameraManager _cameraManager;
        public static ScreenManager _screenManager;



        public static List<Component> _gameComponents;

        public GameEngine()
        {
            _graphics = new GraphicsDeviceManager(this);
            _gameObjectManager = new GameObjectManager();
            _physicsManager = new PhysicsManager();
            _mapGenerator = new MapGenerator(Maps.map1, 12);
            _displayManager = new DisplayManager();
            Window.Title = "Best Game Ever";
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            Mouse.WindowHandle = Window.Handle;
            _displayManager.InitializeDisplay(_graphics, 384, 240);
            _hero = new Hero(_heroTexture);
            _mapGenerator.InitializeBlocks(_tiles, _gameObjectManager);
            _gameObjectManager.AddGameObject(_hero);
            _inputManager = new InputManager(new KeyboardReader(), _hero);
            _background = new Background(_backGroundTexture, _middleGroundTexture);
            _cameraManager = new CameraManager(_hero);
            _screenManager = new ScreenManager();
            _screenManager.SetScreen(new StartScreen(this, Content));
            _screenManager.SwitchScreen();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _screenManager.SetScreen(new StartScreen(this, Content));
                _screenManager.SwitchScreen();
            }
            _screenManager?.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);
            _screenManager?.Draw(_spriteBatch);

            base.Draw(gameTime);
        }


       
    }
}