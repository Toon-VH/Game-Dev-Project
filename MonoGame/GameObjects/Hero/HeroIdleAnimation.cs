using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public class HeroIdleAnimation:Animation
    {
        public HeroIdleAnimation(Texture2D texture) : base(64)
        {
            GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 0, 0);
            AddHitboxes(Frames.Select(_ => new List<RectangleF> { new(25, 6, 16, 22) }).ToList());
        }
    }
}