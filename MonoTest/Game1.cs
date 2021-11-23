using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoTest.Input;
using MonoTest.Tiles;
using System;
using System.Collections.Generic;

namespace MonoTest
{
    public class Game1 : Game
    {
        //private BlockFactory blockFactory;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _heroTexture;
        private Texture2D _backGroundTexture;
        private Texture2D _middleGroundTexture;
        private Texture2D _tiles;
        private Hero hero;
        private Background background;

        private List<Block> blocks;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
           // blockFactory = new BlockFactory();
            //_graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferHeight = 240 * 3;
            _graphics.PreferredBackBufferWidth = 384 * 3;
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
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            background.Draw(_spriteBatch);
            blocks.ForEach((block) => {
                Console.WriteLine(block);
                block.Draw(_spriteBatch);
            });
            hero.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void CreateBlocks()
        {

            blocks.Add(BlockFactory.CreateBlock("normal", 122, 25, GraphicsDevice));

            /*for (int l = 0; l < gameboard.GetLength(0); l++)
            {
                for (int c = 0; k < gameboard.GetLength(1); k++)
                {
                    if (gameboard[l, c] == 1)
                    {
                        blocks.Add(new Block(
                            new Rectangle((c * 10), (l * 10), 10, 10),
                            false,
                            Color.Green,
                            blokTexture));
                    }

                }
            }*/
        }
    }
}