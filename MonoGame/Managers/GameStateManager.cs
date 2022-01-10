using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.GameState;

namespace MonoTest.Managers
{
    public class GameStateManager
    {
        private IGameState _activeGameState;

        public void SetState(IGameState gameState)
        {
            _activeGameState = gameState;
        }

        internal void Update(GameTime gameTime)
        {
            _activeGameState.Update(gameTime);
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            _activeGameState.Draw(spriteBatch);
        }
    }
}