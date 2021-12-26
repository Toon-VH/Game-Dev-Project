using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Controls;
using MonoTest.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest.Screens
{
    class EndScreen : IScreen
    {
        private readonly ContentManager _contentManager;
        private readonly Matrix _scalingMatrix;
        private readonly Texture2D _title;
        private readonly Texture2D _gameOverText;
        private readonly Texture2D _victoryText;
        private readonly Hero _hero;
        private bool heroDead = true;
        private List<Component> _buttons;

        public event EventHandler OnExit;
        public event EventHandler OnRestart;

        public EndScreen(ContentManager contentManager, Matrix scalingMatrix)
        {
            _title = contentManager.Load<Texture2D>("Name");
            _gameOverText = contentManager.Load<Texture2D>("GameOverText");
            _victoryText = contentManager.Load<Texture2D>("VictoryText");
            _contentManager = contentManager;
            _scalingMatrix = scalingMatrix;
           
            LoadUI();
        }
        private void LoadUI()
        {
            var restartButton = new Button(_contentManager.Load<Texture2D>("Button (1)"), _contentManager.Load<SpriteFont>("Font"))
            {
                Position = new Vector2(315, 210),
                Text = "Restart",
                PenColor = Color.CornflowerBlue
            };
            restartButton.Click += RestartButton_Click;

            var quitButton = new Button(_contentManager.Load<Texture2D>("Button (1)"), _contentManager.Load<SpriteFont>("Font"))
            {
                Position = new Vector2(315, 270),
                Text = "Quit",
                PenColor = Color.CornflowerBlue
            };
            quitButton.Click += QuitButton_Click;

            _buttons = new List<Component>()
            {
                restartButton,
                quitButton
            };
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            OnExit?.Invoke(this, EventArgs.Empty);
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: _scalingMatrix);
            spriteBatch.Draw(_title, new Rectangle(225, 10, 300, 100), Color.White);
            if (heroDead)
            {
                spriteBatch.Draw(_gameOverText, new Rectangle(300,130, 155, 55), Color.White);
            }
            else 
            {
                spriteBatch.Draw(_victoryText, new Rectangle(300,130, 150,50), Color.White);

            }
            foreach (var button in _buttons)
            {
                button.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        public void Update(GameTime delta)
        {
            foreach (var button in _buttons)
            {
                button.Update(delta, _scalingMatrix);
            }
        }
    }
}
