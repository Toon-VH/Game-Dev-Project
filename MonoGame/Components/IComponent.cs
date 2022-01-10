using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.Components
{
    public interface IComponent
    {
        public void Draw(SpriteBatch spriteBatch);
        public void Update(GameTime gameTime, Matrix matrix);
    }
}
