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
        private Texture2D _gorillaTexture;
        private Texture2D _spiderTexture;
        private SoundEffect _jumpSound;
        private SoundEffect _hitSound;
        private SoundEffect _gorillaRoarSound;
        private SoundEffect _gameOverSound;
        private SoundEffect _gorillaHitSound;
        private SoundEffect _spiderHitSound;
        private SoundEffectInstance _bgSoundInstance;
        private MapGenerator _mapGenerator;
        private GameScreen _gameScreen;
        private StartScreen _startScreen;
        private EndScreen _endScreen;
        private int _level;
        private bool _nextLevel;

        public GameEngine()
        {
            _level = 1;
            _graphics = new GraphicsDeviceManager(this);
            _gameObjectManager = new GameObjectManager();
            _physicsManager = new PhysicsManager();
            _mapGenerator = new MapGenerator(Maps.Map1, Maps.Objects1, 24);
            //_mapGenerator = new MapGenerator(Maps.Map2, Maps.Map2Obj, 24);
            //_mapGenerator = new MapGenerator(Maps.Map3, Maps.Map3Obj, 24);
            _displayManager = new DisplayManager();
            Window.Title = "Best Game Ever";
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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
            _gorillaRoarSound = Content.Load<SoundEffect>("Sounds/Lion-roar");
            _gorillaHitSound = Content.Load<SoundEffect>("Sounds/hitGorilla");
            _spiderHitSound = Content.Load<SoundEffect>("Sounds/spinHit");
            _mapGenerator.InitializeGameObjects(_texturePlants, _gorillaTexture, _spiderTexture, _gameObjectManager,
                _gorillaRoarSound, _gorillaHitSound, _spiderHitSound);
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
            _heroTexture = Content.Load<Texture2D>("Sprites/Archaeologist Sprite Sheet");
            _gorillaTexture = Content.Load<Texture2D>("Enemies/Giant Gorilla Sprite Sheet");
            _spiderTexture = Content.Load<Texture2D>("Enemies/Spider Sprite Sheet");
            _backGroundTexture = Content.Load<Texture2D>("Backgrounds/background");
            _middleGroundTexture = Content.Load<Texture2D>("Backgrounds/middleground");
            _tiles = Content.Load<Texture2D>("Tiles/Tiles");
            _texturePlants = Content.Load<Texture2D>("Enemies/Plants");
            _jumpSound = Content.Load<SoundEffect>("Sounds/jump");
            _hitSound = Content.Load<SoundEffect>("Sounds/hitHurt");
            _gameOverSound = Content.Load<SoundEffect>("Sounds/gameover2");
            _bgSoundInstance = Content.Load<SoundEffect>("Sounds/bg-song").CreateInstance();
        }

        protected override void Update(GameTime gameTime)
        {
            if (_nextLevel) SwitchLevel();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _bgSoundInstance.Pause();
                IsMouseVisible = true;
                _screenManager.SetScreen(_startScreen);
            }

            _screenManager.Update(gameTime);
            base.Update(gameTime);
        }

        private void SwitchLevel()
        {
            switch (_level)
            {
                case 2:
                    _mapGenerator = new MapGenerator(Maps.Map2, Maps.Map2Obj, 24);
                    _gameObjectManager = new GameObjectManager();
                    _mapGenerator.InitializeBlocks(_tiles, _gameObjectManager);
                    _gameObjectManager.AddGameObject(_hero);
                    _mapGenerator.InitializeGameObjects(_texturePlants, _gorillaTexture, _spiderTexture,
                        _gameObjectManager,
                        _gorillaRoarSound, _gorillaHitSound, _spiderHitSound);
                    // _bgSoundInstance.Play();
                    // _hero = new Hero(_heroTexture, _hitSound);
                    // _cameraManager = new CameraManager(_hero, _graphics, _displayManager);
                    _gameScreen = InitializeGameScreen();
                    _hero.Position = new Vector2(30, 200);
                    break;
                case 3:
                    _screenManager.SetScreen(_endScreen);
                    break;
            }

            _nextLevel = false;
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
            var gameScreen = new GameScreen(_displayManager, _gameObjectManager, _cameraManager, _physicsManager, _inputManager, _graphics.GraphicsDevice, _hero, Content);
            gameScreen.OnDead += (sender, args) =>
            {
                IsMouseVisible = true;
                _bgSoundInstance.Stop();
                _gameOverSound.Play();
                _screenManager.SetScreen(_endScreen);
            };
            gameScreen.OnFinish += (sender, args) =>
            {
                _bgSoundInstance.Pause();
                _level++;
                _nextLevel = true;
                _hero.IsFinished = false;
            };
            return gameScreen;
        }

        private StartScreen InitializeStartScreen()
        {
            var startScreen = new StartScreen(Content, _displayManager);
            startScreen.OnExit += (sender, args) => Exit();
            startScreen.OnStart += (sender, args) =>
            {
                IsMouseVisible = false;
                _bgSoundInstance.Play();
                _bgSoundInstance.IsLooped = true;
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
                _cameraManager.Cinematic = true;
                _screenManager.SetScreen(InitializeGameScreen());
            };
            return endScreen;
        }
    }
}