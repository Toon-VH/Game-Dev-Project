using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest
{
    class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }
        

        public AnimationFrame(Rectangle sourceRectangle)
        {
            SourceRectangle = sourceRectangle;
        }

    }
}
