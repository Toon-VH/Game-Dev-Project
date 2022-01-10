using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public class SpiderIdleAnimation : Animation
    {
        public SpiderIdleAnimation(Texture2D texture, int frameWidth) : base(frameWidth)
        {
            GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 9, 9 - 5, 0);

            AddHitboxes(0, new List<RectangleF> { new(10, 24, 12, 7)});
            AddHitboxes(1, new List<RectangleF> { new(9, 25, 13, 7)});
            AddHitboxes(2, new List<RectangleF> { new(9, 25, 13, 7)});
            AddHitboxes(3, new List<RectangleF> { new(10, 24, 12, 8)});
            AddHitboxes(4, new List<RectangleF> { new(10, 23, 12, 9)});
            
            AddAttackBoxes(0, new List<RectangleF> { new(10, 24, 12, 7)});
            AddAttackBoxes(1, new List<RectangleF> { new(9, 25, 13, 7)});
            AddAttackBoxes(2, new List<RectangleF> { new(9, 25, 13, 7)});
            AddAttackBoxes(3, new List<RectangleF> { new(10, 24, 12, 8)});
            AddAttackBoxes(4, new List<RectangleF> { new(10, 23, 12, 9)});
        }
    }
}