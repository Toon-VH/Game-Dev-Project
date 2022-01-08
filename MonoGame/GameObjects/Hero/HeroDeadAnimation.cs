using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public class HeroDeadAnimation :Animation
    {
        public HeroDeadAnimation(Texture2D texture) : base(64)
        {
            GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 3, 6);
        }
    }
}