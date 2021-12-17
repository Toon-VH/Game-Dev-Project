using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MonoTest.Screens
{
    class StartScreen : IScreen
    {
        private List<Component> _gameComponents;
        private GameEngine _game;
        private Texture2D _name;
        public StartScreen( GameEngine game,ContentManager content)
        {
            _name = content.Load<Texture2D>("Name");
            _game = game;
            var startButton = new Button(content.Load<Texture2D>("Button (1)"), content.Load<SpriteFont>("Font"))
            {
                
                Position = new Vector2(133, 100),
                Text = "start",
                PenColor = Color.CornflowerBlue
            };
            startButton.Click += new EventHandler(StartButton_Click);

            var quitButton = new Button(content.Load<Texture2D>("Button (1)"), content.Load<SpriteFont>("Font"))
            {
                Position = new Vector2(133, 150),
                Text = "Quit",
                PenColor = Color.CornflowerBlue
            };
            quitButton.Click += new EventHandler( QuitButton_Click);

            _gameComponents = new List<Component>()
            {
                startButton,
                quitButton
            };
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            GameEngine._screenManager.SetScreen(new GameScreen());
           
        }

        public void Draw(SpriteBatch _spriteBatch)
        {

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: GameEngine._displayManager.CalculateMatrix());



            GameEngine._background.Draw(_spriteBatch);

            _spriteBatch.Draw(_name,new Rectangle(100,10,200,50),Color.White);
            foreach (var item in _gameComponents)
            {
                item.Draw(_spriteBatch);

            }
            _spriteBatch.End();
        }

        public void Update(GameTime delta)
        {
            GameEngine._screenManager.SwitchScreen();
            foreach (var item in _gameComponents)
            {
                item.Update(delta);

            }
        }
    }
}
