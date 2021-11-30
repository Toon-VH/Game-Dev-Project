using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoTest.Input;
using MonoTest.Tiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MonoTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _heroTexture;
        private Texture2D _backGroundTexture;
        private Texture2D _middleGroundTexture;
        private Texture2D _tiles;
        private Hero hero;
        private Background background;
        private int ActualWidth;
        private int ActualHeight;
        private int SizeBlock;
        private List<Block> blocks;
        int[,] gameboard = new int[,]{{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                      {0,0,0,0,0,3,0,0,0,0,0,3,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,0,0,0,0,0,0},
                                      {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                                      {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                                      {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                                      {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                                      {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}};
                                                  
        private Matrix Matrix;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            ActualWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            ActualHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            SizeBlock = 12;
            var scaleX = (double)ActualWidth / 384;
            var scaleY = (double)ActualHeight / 240;
            Matrix = Matrix.CreateScale((float)scaleX, (float)scaleY, 1.0f);
            _graphics.PreferredBackBufferWidth = ActualWidth;
            _graphics.PreferredBackBufferHeight = ActualHeight;
            _graphics.IsFullScreen = true;
            Window.Title = "Title";
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            blocks = new List<Block>();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            hero = new Hero(_heroTexture, new KeyboardReader());
            background = new Background(_backGroundTexture, _middleGroundTexture);
            CreateBlocks();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            _heroTexture = Content.Load<Texture2D>("Archaeologist Sprite Sheet");
            _backGroundTexture = Content.Load<Texture2D>("background");
            _middleGroundTexture = Content.Load<Texture2D>("middleground");
            _tiles = Content.Load<Texture2D>("tileset");
            Debug.WriteLine(_tiles.Width);
            Debug.WriteLine(_tiles.Height);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            hero.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);
            _spriteBatch.Begin(samplerState:SamplerState.PointClamp,transformMatrix: Matrix);

            background.Draw(_spriteBatch);
            blocks.ForEach(block =>
            {
                if (block != null)
                {
                    block.Draw(_spriteBatch, GraphicsDevice);
                }
            });
            hero.Draw(_spriteBatch, GraphicsDevice);

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void CreateBlocks()
        {
            for (var y = 0; y < gameboard.GetLength(0); y++)
            {
                for (var x = 0; x < gameboard.GetLength(1); x++)
                {
                    blocks.Add(BlockFactory.CreateBlock((BlockType)gameboard[y, x], x, y, _tiles, SizeBlock));
                }
            }
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