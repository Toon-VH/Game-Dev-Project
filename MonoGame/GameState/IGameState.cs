using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.GameState
{
    public interface IGameState
    {
        void Update(GameTime delta);

        void Draw(SpriteBatch spriteBatch);
    }
}
