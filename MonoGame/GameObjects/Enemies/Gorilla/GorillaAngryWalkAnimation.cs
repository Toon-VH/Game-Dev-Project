using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects.Enemies
{
    public class GorillaAngryWalkAnimation :Animation
    {
        public GorillaAngryWalkAnimation(Texture2D texture,int frameWidth) : base(frameWidth)
        {
            GetFramesFromTextureProperties(texture.Width, texture.Height, 10, 12, 12 - 6, 3);
            AddHitboxes(Frames.Select(_ => new List<RectangleF> { new(16, 21, 29, 37),new (12, 54, 29,11) }).ToList());
            AddAttackBoxes(Frames.Select(_ => new List<RectangleF> { new(16, 21, 29, 37),new (12, 54, 29,11) }).ToList());
        }
    }
}