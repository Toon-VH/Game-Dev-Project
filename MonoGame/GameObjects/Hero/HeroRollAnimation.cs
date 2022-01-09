using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public class HeroRollAnimation:Animation
    {
        public HeroRollAnimation(Texture2D texture) : base(64)
        {
            GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 2, 2);

            AddHitboxes(0, new List<RectangleF>{new(25, 6, 16, 22) });
            AddHitboxes(1, new List<RectangleF>{new(23, 9, 22, 17) });
            AddHitboxes(2, new List<RectangleF>{new(23, 10, 22, 17) });
            AddHitboxes(3, new List<RectangleF>{new(22, 13, 23, 15) });
            AddHitboxes(4, new List<RectangleF>{new(24, 12, 21, 16)});
            AddHitboxes(5, new List<RectangleF>{new(26, 10, 16, 19)});
        }
    }
}