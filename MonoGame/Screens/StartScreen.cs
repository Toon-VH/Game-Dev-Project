using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using MonoTest.Components;
using MonoTest.Managers;
using SharpDX.Direct2D1.Effects;

namespace MonoTest.Screens
{
    public class StartScreen : IScreen
    {
        private readonly ContentManager _contentManager;
        private readonly DisplayManager _displayManager;
        private readonly Texture2D _title;
        private readonly Texture2D _keyMap;

        private List<Component> _buttons;

        public event EventHandler OnExit;
        public event EventHandler OnStart;

        public StartScreen(ContentManager contentManager, DisplayManager displayManager)
        {
            _title = contentManager.Load<Texture2D>("Components/Name");
            _keyMap = contentManager.Load<Texture2D>("Components/KeyMap");

            _contentManager = contentManager;
            _displayManager = displayManager;
            LoadUI();
        }

        private void LoadUI()
        {
            var texture = _contentManager.Load<Texture2D>("Components/Button (1)");
            var startButton = new Button(texture, _contentManager.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(_displayManager.GetMiddlePointScreen - texture.Width / 2, 200),
                Text = "Start",
                PenColor = Color.CornflowerBlue
            };
            startButton.Click += StartButton_Click;

            var quitButton = new Button(texture, _contentManager.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(_displayManager.GetMiddlePointScreen - texture.Width / 2, 250),
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
            spriteBatch.Begin(transformMatrix: _displayManager.CalculateMatrix());
            spriteBatch.Draw(_title, new Vector2(_displayManager.GetMiddlePointScreen - _title.Width * 0.5f / 2, 40),
                null, Color.White, 0f,
                Vector2.Zero, 0.5f, SpriteEffects.None, 0f);

            var width = GraphicsDeviceManager.DefaultBackBufferWidth;
            var height = GraphicsDeviceManager.DefaultBackBufferHeight;


            spriteBatch.Draw(_keyMap, new Vector2(width - _keyMap.Width*0.35f-50, height - _keyMap.Height*0.35f), null, Color.White,
                0f, Vector2.Zero, 0.35f, SpriteEffects.None, 0f);


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