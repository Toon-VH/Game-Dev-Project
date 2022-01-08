using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoTest.Animations
{
    public class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }
        public List<RectangleF> HitBoxes { get; set; }
        public List<RectangleF> AttackBoxes { get; set; }

        public AnimationFrame(Rectangle sourceRectangle)
        {
            SourceRectangle = sourceRectangle;
        }

        
    }
}