using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Animations;

namespace MonoTest.GameObjects.Enemies
{
    public class GorillaChestPound : Animation
    {
        public GorillaChestPound(Texture2D texture, int frameWidth) : base(frameWidth)
        {
            GetFramesFromTextureProperties(texture.Width, texture.Height, 10, 12, 12 - 4, 6);
            AddHitboxes(0, new List<RectangleF> { new(12, 20, 26, 43), new(38, 29, 16, 12) });
            AddHitboxes(1, new List<RectangleF> { new(12, 20, 26, 43), new(38, 29, 16, 12) });
            AddHitboxes(2, new List<RectangleF> { new(12, 31, 30, 32), new(3, 29, 10, 10), new(20, 20, 19, 12) });
            AddHitboxes(3, new List<RectangleF> { new(12, 31, 30, 32), new(3, 29, 10, 10), new(20, 20, 19, 12) });
            
            AddAttackBoxes(0, new List<RectangleF> { new(12, 20, 26, 43), new(38, 29, 16, 12) });
            AddAttackBoxes(1, new List<RectangleF> { new(12, 20, 26, 43), new(38, 29, 16, 12) });
            AddAttackBoxes(2, new List<RectangleF> { new(12, 31, 30, 32), new(3, 29, 10, 10), new(20, 20, 19, 12) });
            AddAttackBoxes(3, new List<RectangleF> { new(12, 31, 30, 32), new(3, 29, 10, 10), new(20, 20, 19, 12) });
        }
    }
}