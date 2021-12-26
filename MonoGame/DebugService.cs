using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTest
{
    public static class DebugService
    {
        public static void DrawRectangle(SpriteBatch spriteBatch, RectangleF rectangle, int lineWidth, bool isIntersecting)
        {
            var color = isIntersecting ? Color.Red : Color.Green;
            var pointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            pointTexture.SetData(new[]
            {
                Color.White
            });

            spriteBatch.Draw(pointTexture, rectangle.Position, null, color, 0f, Vector2.Zero,
                new Vector2(rectangle.Width, lineWidth), SpriteEffects.None, 0f);
            spriteBatch.Draw(pointTexture, rectangle.Position, null, color, 0f, Vector2.Zero,
                new Vector2(lineWidth, rectangle.Height), SpriteEffects.None, 0f);
            spriteBatch.Draw(pointTexture, new Vector2(rectangle.X + rectangle.Width, rectangle.Y), null, color, 0f,
                Vector2.Zero, new Vector2(lineWidth, rectangle.Height), SpriteEffects.None, 0f);
            spriteBatch.Draw(pointTexture, new Vector2(rectangle.X, rectangle.Y + rectangle.Height), null, color, 0f,
                Vector2.Zero, new Vector2(rectangle.Width + lineWidth, lineWidth), SpriteEffects.None, 0f);
        }
    }
}