using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Controls;
using MonoTest.GameObjects;
using System;
using System.Collections.Generic;
using MonoTest.Components;
using MonoTest.Managers;

namespace MonoTest.Screens
{
    class EndScreen : IScreen
    {
        private readonly ContentManager _contentManager;
        private readonly DisplayManager _displayManager;
        private readonly Texture2D _title;
        private readonly Texture2D _gameOverText;
        private readonly Texture2D _victoryText;
        private readonly Hero _hero;
        private List<Component> _buttons;

        public event EventHandler OnExit;
        public event EventHandler OnRestart;

        public EndScreen(ContentManager contentManager, DisplayManager displayManager, Hero hero)
        {
            _title = contentManager.Load<Texture2D>("Components/Name");
            _gameOverText = contentManager.Load<Texture2D>("Components/GameOverText");
            _victoryText = contentManager.Load<Texture2D>("Components/VictoryText");
            _contentManager = contentManager;
            _displayManager = displayManager;
            _hero = hero;

            LoadUI();
        }
        private void LoadUI()
        {
            var texture = _contentManager.Load<Texture2D>("Components/Button (1)");
            var restartButton = new Button(texture, _contentManager.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(_displayManager.GetMiddlePointScreen - texture.Width/2, 210),
                Text = "Restart",
                PenColor = Color.CornflowerBlue
            };
            restartButton.Click += RestartButton_Click;

            var quitButton = new Button(texture, _contentManager.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(_displayManager.GetMiddlePointScreen - texture.Width/2 , 270),
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
            OnRestart?.Invoke(this, EventArgs.Empty);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: _displayManager.CalculateMatrix());
            spriteBatch.Draw(_title, new Vector2(_displayManager.GetMiddlePointScreen - _title.Width/4, 40), null, Color.White, 0f,
                Vector2.Zero, 0.5f,SpriteEffects.None, 0f);
            if (_hero.Health <= 0)
            {
                spriteBatch.Draw(_gameOverText, new Vector2(_displayManager.GetMiddlePointScreen - _gameOverText.Width/4, 120), null, Color.White, 0f,
                    Vector2.Zero, 0.5f,SpriteEffects.None, 0f);
            }
            else 
            {
                spriteBatch.Draw(_victoryText, new Vector2(_displayManager.GetMiddlePointScreen - _victoryText.Width/4, 120), null, Color.White, 0f,
                    Vector2.Zero, 0.5f,SpriteEffects.None, 0f);

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
                button.Update(delta, _displayManager.CalculateMatrix());
            }
        }
    }
}
