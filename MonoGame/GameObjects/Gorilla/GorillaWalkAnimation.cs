﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects
{
    public class GorillaWalkAnimation : Animation
    {
        public GorillaWalkAnimation(Texture2D texture, int frameWidth) : base(frameWidth)
        {
            GetFramesFromTextureProperties(texture.Width, texture.Height, 10, 12, 12 - 6, 1);
            AddHitboxes(Frames.Select(_ => new List<RectangleF> { new(12, 51, 34, 12),new (16, 43, 31,8),new(21,27,23,16) }).ToList());
            AddAttackBoxes(Frames.Select(_ => new List<RectangleF> { new(12, 51, 34, 12),new (16, 43, 31,8),new(21,27,23,16) }).ToList());
        }
    }
}