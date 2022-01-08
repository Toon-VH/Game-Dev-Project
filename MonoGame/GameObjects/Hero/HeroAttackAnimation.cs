using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public class HeroAttackAnimation:Animation
    {
        public HeroAttackAnimation(Texture2D texture) : base(64)
        {
            GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 8, 1, 4);
            
            AddHitboxes(0, new List<RectangleF>{new(25, 6, 15, 22) });
            AddHitboxes(1, new List<RectangleF>{new(25, 15, 5, 6), new(30, 8, 13, 20) });
            AddHitboxes(2, new List<RectangleF>{new(22, 18, 4, 5), new (26, 7, 13, 21) });
            AddHitboxes(3, new List<RectangleF>{new(25, 6, 15, 22) });
            AddHitboxes(4, new List<RectangleF>{new(26, 18, 4, 6),new(29, 6, 12, 22)});
            AddHitboxes(5, new List<RectangleF>{new(29, 6, 12, 22)});
            AddHitboxes(6, new List<RectangleF>{new(27, 6, 13, 22),new(40, 18, 4, 5)});

            AddAttackBoxes(0, new List<RectangleF>{new(11, 5, 6, 5), new(15, 10, 6, 9)});
            AddAttackBoxes(1, new List<RectangleF>{new(44, 8, 4, 8), new(47, 7, 16, 5)});
            AddAttackBoxes(2, new List<RectangleF>{new(38, 12, 25, 5)});
            AddAttackBoxes(3, new List<RectangleF>{new(1, 10, 25, 4) });
            AddAttackBoxes(4, new List<RectangleF>{ new(15, 1, 6, 5), new(19,6,4,8),new(22,12,7,3)});
            AddAttackBoxes(5, new List<RectangleF>{ new(25,1,21,4), new(41,5,5,4) });
            AddAttackBoxes(6, new List<RectangleF>{ new(42,11,8,9)});
        }
    }
}