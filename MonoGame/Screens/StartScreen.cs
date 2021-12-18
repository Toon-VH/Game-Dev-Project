using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Controls;
using System;
using System.Collections.Generic;

namespace MonoTest.Screens
{
    public class StartScreen : IScreen
    {
        private readonly ContentManager _contentManager;
        private readonly Matrix _scalingMatrix;
        private readonly Texture2D _title;
        
        private List<Component> _buttons;

        public event EventHandler OnExit;
        public event EventHandler OnStart;
        
        public StartScreen(ContentManager contentManager, Matrix scalingMatrix)
        {
            _title = contentManager.Load<Texture2D>("Name");
            _contentManager = contentManager;
            _scalingMatrix = scalingMatrix;
            LoadUI();
        }

        private void LoadUI()
        {
            var startButton = new Button(_contentManager.Load<Texture2D>("Button (1)"), _contentManager.Load<SpriteFont>("Font"))
            {
                Position = new Vector2(133, 100),
                Text = "start",
                PenColor = Color.CornflowerBlue
            };
            startButton.Click += StartButton_Click;

            var quitButton = new Button(_contentManager.Load<Texture2D>("Button (1)"), _contentManager.Load<SpriteFont>("Font"))
            {
                Position = new Vector2(133, 150),
                Text = "Quit",
                PenColor = Color.CornflowerBlue
            };
            quitButton.Click += QuitButton_Click;

            _buttons = new List<Component>()
            {
                startButton,
                quitButton
            };
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            OnExit?.Invoke(this, EventArgs.Empty);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            OnStart?.Invoke(this, EventArgs.Empty);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: _scalingMatrix);
            spriteBatch.Draw(_title,new Rectangle(100,10,200,50),Color.White);
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
