using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.GameObjects;
using MonoTest.Managers;
using System;
using System.Collections.Generic;

using System.Text;


namespace MonoTest.Screens
{
    class GameScreen : IScreen
    {



        public void Draw(SpriteBatch _spriteBatch)
        {

          
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: GameEngine._displayManager.CalculateMatrix());

            GameEngine._background.Draw(_spriteBatch);
            _spriteBatch.End();

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: CreateMatrix());
            GameEngine._gameObjectManager.GameObjects.ForEach(gameObject => gameObject?.Draw(_spriteBatch, GameEngine._graphics.GraphicsDevice));
            GameEngine._cameraManager.Update(_spriteBatch, GameEngine._graphics.GraphicsDevice);
            _spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            GameEngine._inputManager.ProcessInput();
            GameEngine._hero.Update(gameTime);
            GameEngine._gameObjectManager.Moveables.ForEach(m => GameEngine._physicsManager.Move(m, (float)gameTime.ElapsedGameTime.TotalSeconds,
            GameEngine._gameObjectManager.GameObjects));

        }

        private Matrix CreateMatrix()
        {
            return GameEngine._displayManager.CalculateMatrix() * Matrix.CreateTranslation(new Vector3(
                (-GameEngine._cameraManager.GetCameraPosition().X * GameEngine._displayManager.GetScaleX()) +
                ((float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2), 0, 0));
        }
    }
}
