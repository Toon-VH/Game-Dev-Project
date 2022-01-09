using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public class SpiderWalkAnimation : Animation
    {
        public SpiderWalkAnimation(Texture2D texture, int frameWidth) : base(frameWidth)
        {
            GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 9, 9 - 6, 1);

            AddHitboxes(0, new List<RectangleF> { new(11, 24, 11, 8) });
            AddHitboxes(1, new List<RectangleF> { new(10, 24, 12, 8) });
            AddHitboxes(2, new List<RectangleF> { new(9, 26, 3, 7), new(12, 23, 10, 9) });
            AddHitboxes(3, new List<RectangleF> { new(11, 24, 11, 8) });
            AddHitboxes(4, new List<RectangleF> { new(12, 23, 10, 9) });
            AddHitboxes(5, new List<RectangleF> { new(12, 23, 10, 8) });
            
            AddAttackBoxes(0, new List<RectangleF> { new(11, 24, 11, 8) });
            AddAttackBoxes(1, new List<RectangleF> { new(10, 24, 12, 8) });
            AddAttackBoxes(2, new List<RectangleF> { new(9, 26, 3, 7), new(12, 23, 10, 9) });
            AddAttackBoxes(3, new List<RectangleF> { new(11, 24, 11, 8) });
            AddAttackBoxes(4, new List<RectangleF> { new(12, 23, 10, 9) });
            AddAttackBoxes(5, new List<RectangleF> { new(12, 23, 10, 8)});

            
        }
    }
}