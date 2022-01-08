using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public class GorillaDeadAnimation : Animation
    {
        public GorillaDeadAnimation(Texture2D texture, int frameWidth) : base(frameWidth)
        {
            GetFramesFromTextureProperties(texture.Width, texture.Height, 10, 12, 12 - 5, 8);
        }
    }
}