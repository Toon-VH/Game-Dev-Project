using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public class HeroAttackAnimation:Animation
    {
        public HeroAttackAnimation(Texture2D texture) : base(64)
        {
            GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 3, 3);
            
            AddHitboxes(0, new List<RectangleF>{new(24, 6, 15, 22) });
            AddHitboxes(1, new List<RectangleF>{new(24, 15, 5, 6), new(29, 8, 12, 20) });
            AddHitboxes(2, new List<RectangleF>{new(23, 18, 5, 5), new (27, 7, 13, 21) });
            AddHitboxes(3, new List<RectangleF>{new(25, 6, 13, 22) });
            AddHitboxes(4, new List<RectangleF>{new(25, 6, 16, 22)});
            //AddHitboxes(5, new List<RectangleF>{new(25, 6, 15, 22)});

            AddAttackBoxes(0, new List<RectangleF>{new(10, 5, 6, 5), new(14, 10, 7, 9)});
            AddAttackBoxes(1, new List<RectangleF>{new(42, 23, 14, 5), new(49, 16, 7, 5), new(43, 12, 6, 6)});
            AddAttackBoxes(2, new List<RectangleF>{new(41, 9, 20, 9) });
            AddAttackBoxes(3, new List<RectangleF>{ new(40, 6, 9, 15) });
        }
    }
}