using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.GameObjects
{
    public interface IGameObject
    {
       
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics);

    }
}
