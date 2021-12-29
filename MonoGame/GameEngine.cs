using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoTest.GameObjects;
using MonoTest.Input;
using MonoTest.Managers;
using MonoTest.Map;
using MonoTest.Screens;

namespace MonoTest
{
    public class GameEngine : Game
    {
        private Background _background;
        private Hero _hero;
        private DisplayManager _displayManager;
        private GameObjectManager _gameObjectManager;
        private GraphicsDeviceManager _graphics;
        private PhysicsManager _physicsManager;
        private InputManager _inputManager;
        private CameraManager _cameraManager;
        private ScreenManager _screenManager;

        private SpriteBatch _spriteBatch;
        private Texture2D _backGroundTexture;
        private Texture2D _heroTexture;
        private Texture2D _middleGroundTexture;
        private Texture2D _tiles;
        private Texture2D _texturePlants;
        private Texture2D _gorilla;
        private SoundEffect _jumpSound;
        private SoundEffect _hitSound;
        private SoundEffect _gorillaRoarSound;
        private SoundEffect _gameOverSound;
        private SoundEffectInstance _bgSoundInstance;
        private readonly MapGenerator _mapGenerator;
        private GameScreen _gameScreen;
        private StartScreen _startScreen;
        private EndScreen _endScreen;
        private int _milliSecondsSinceRestart;

        public GameEngine()
        {
            _graphics = new GraphicsDeviceManager(this);
            _gameObjectManager = new GameObjectManager();
            _physicsManager = new PhysicsManager();
             // _mapGenerator = new MapGenerator(Maps.Map2, Maps.Objects2, 24);
            //_mapGenerator = new MapGenerator(Maps.Map2, Maps.Objects2, 24);
            _mapGenerator = new MapGenerator(Maps.ToonMap, Maps.ToonObjects, 24);
            _displayManager = new DisplayManager();
            Window.Title = "Best Game Ever";
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _milliSecondsSinceRestart = 0;
        }

        protected override void Initialize()
        {
            base.Initialize();
            Mouse.WindowHandle = Window.Handle;
            _displayManager.InitializeDisplay(_graphics, 384 * 2, 240 * 2);
            _hero = new Hero(_heroTexture, _hitSound);
            _mapGenerator.InitializeBlocks(_tiles, _gameObjectManager);
            _gameObjectManager.AddGameObject(_hero);
            _inputManager = new InputManager(new KeyboardReader(), _hero, _jumpSound);
            _background = new Background(_backGroundTexture, _middleGroundTexture);
            _gorillaRoarSound = Content.Load<SoundEffect>("Lion-roar");
            _mapGenerator.InitializePlants(_texturePlants, _gorilla, _gameObjectManager, _gorillaRoarSound);
            _cameraManager = new CameraManager(_hero, _graphics, _displayManager);
            _screenManager = new ScreenManager();
            _gameScreen = InitializeGameScreen();
            _startScreen = InitializeStartScreen();
            _endScreen = InitializeEndScreen();
            _screenManager.SetScreen(_startScreen);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _heroTexture = Content.Load<Texture2D>("Archaeologist Sprite Sheet");
            _gorilla = Content.Load<Texture2D>("Giant Gorilla Sprite Sheet");
            _backGroundTexture = Content.Load<Texture2D>("background");
            _middleGroundTexture = Content.Load<Texture2D>("middleground");
            _tiles = Content.Load<Texture2D>("tileset");
            _texturePlants = Content.Load<Texture2D>("Plants");
            _jumpSound = Content.Load<SoundEffect>("jump");
            _hitSound = Content.Load<SoundEffect>("hitHurt");
            _gameOverSound = Content.Load<SoundEffect>("gameover2");
            _bgSoundInstance = Content.Load<SoundEffect>("bg-song").CreateInstance();
        }

        protected override void Update(GameTime gameTime)
        {
            _milliSecondsSinceRestart += gameTime.ElapsedGameTime.Milliseconds;
            // if(_milliSecondsSinceRestart > 3000)
            // {
            //     _cameraManager.MaxVelocity = 6000;
            //     _cameraManager.MinVelocity = 700;
            // }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _screenManager.SetScreen(_startScreen);
            }

            _screenManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp,
                transformMatrix: _displayManager.CalculateMatrix());
            _background.Draw(_spriteBatch);
            _spriteBatch.End();

            _screenManager.Draw(_spriteBatch);
            base.Draw(gameTime);
        }

        private GameScreen InitializeGameScreen()
        {
            _hero.Health = _hero.InitialHealth;
            var gameScreen = new GameScreen(_displayManager, _gameObjectManager, _cameraManager, _physicsManager,
                _inputManager,
                _graphics.GraphicsDevice, _hero, Content);
            gameScreen.OnDead += (sender, args) =>
            {
                _bgSoundInstance.Stop();
                _gameOverSound.Play();
                _screenManager.SetScreen(_endScreen);
            };
            return gameScreen;
        }

        private StartScreen InitializeStartScreen()
        {
            var startScreen = new StartScreen(Content, _displayManager);
            startScreen.OnExit += (sender, args) => Exit();
            startScreen.OnStart += (sender, args) =>
            {
                _bgSoundInstance.Play();
                _screenManager.SetScreen(_gameScreen);
            };
            return startScreen;
        }

        private EndScreen InitializeEndScreen()
        {
            var endScreen = new EndScreen(Content, _displayManager, _hero);
            endScreen.OnExit += (sender, args) => Exit();
            endScreen.OnRestart += (sender, args) =>
            {
                _bgSoundInstance.Play();
                _hero.Position = new Vector2(30, 200);
                _milliSecondsSinceRestart = 0;
                _cameraManager.Cinematic = true;
                _screenManager.SetScreen(InitializeGameScreen());
            };
            return endScreen;
        }
    }
}