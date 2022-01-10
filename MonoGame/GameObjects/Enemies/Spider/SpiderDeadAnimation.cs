using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects.Enemies
{
    public class SpiderDeadAnimation : Animation
    {
        public SpiderDeadAnimation(Texture2D texture ,int frameWidth) : base(frameWidth)
        {
            GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 9, 0, 6);

        }
    }
}