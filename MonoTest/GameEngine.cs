using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoTest.Input;
using MonoTest.Tiles;
using MonoTest.Hero;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using MonoTest.Map;
using MonoTest.Map.Maps;

namespace MonoTest
{
    public class GameEngine : Game
    {
        private GraphicsDeviceManager _graphics;
        private MapGenerator _mapGenerator;

        private SpriteBatch _spriteBatch;
        //private State _state;

        private Texture2D _heroTexture;
        private Texture2D _backGroundTexture;
        private Texture2D _middleGroundTexture;
        private Texture2D _tiles;
        private Hero1 _hero;
        private Background background;
        private int ActualWidth;
        private int ActualHeight;
        private int SizeBlock;
        private List<IGameObject> _gameObjects;
        
        private Matrix Matrix;

        public GameEngine()
        {
            _mapGenerator = new MapGenerator(_tiles, Maps.map1, 12, _gameObjects);
            _graphics = new GraphicsDeviceManager(this);
            ActualWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            ActualHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            var scaleX = (double) ActualWidth / 384;
            var scaleY = (double) ActualHeight / 240;
            Matrix = Matrix.CreateScale((float) scaleX, (float) scaleY, 1.0f);
            _graphics.PreferredBackBufferWidth = ActualWidth;
            _graphics.PreferredBackBufferHeight = ActualHeight;
            _graphics.IsFullScreen = true;
            Window.Title = "Title";
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _gameObjects = new List<IGameObject>();
        }

        protected override void Initialize()
        {
            base.Initialize();
            _hero = new Hero1(_heroTexture, new KeyboardReader());
            _gameObjects.Add(_hero);
            background = new Background(_backGroundTexture, _middleGroundTexture);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _heroTexture = Content.Load<Texture2D>("Archaeologist Sprite Sheet");
            _backGroundTexture = Content.Load<Texture2D>("background");
            _middleGroundTexture = Content.Load<Texture2D>("middleground");
            _tiles = Content.Load<Texture2D>("tileset");
            Debug.WriteLine(_tiles.Width);
            Debug.WriteLine(_tiles.Height);
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
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Matrix);

            background.Draw(_spriteBatch);
            _gameObjects.ForEach(_gameObject =>
            {
                if (_gameObject != null)
                {
                    _gameObject.Draw(_spriteBatch, GraphicsDevice);
                }
            });
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
    }
}