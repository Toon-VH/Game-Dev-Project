using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonoTest.Animations
{
    public class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        public RectangleF CurrentHitbox { get; set; }
        public bool AnimationDoneFlag { get; set; }
        public readonly List<AnimationFrame> Frames;
        private Double _secondCounter = 0;
        private List<RectangleF> _hitboxes;


        public int Counter;

        public Animation()
        {
            Frames = new List<AnimationFrame>();
            _hitboxes = new List<RectangleF>();
        }

        public void AddFrame(AnimationFrame frame)
        {
            Frames.Add(frame);
            CurrentFrame = Frames[0];
        }

        public void AddHitboxList(List<RectangleF> hitboxes)
        {
            _hitboxes = hitboxes;
            CurrentHitbox = _hitboxes[0];
        }

        public void Update(GameTime gameTime)
        {
            AnimationDoneFlag = false;
            CurrentFrame = Frames[Counter];

            if (_hitboxes.Any())
            {
                CurrentHitbox = _hitboxes[Counter];
            }

            _secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            var fps = 12;
            if (_secondCounter >= 1d / fps)
            {
                Counter++;
                _secondCounter = 0;
            }

            if (Counter >= Frames.Count)
            {
                AnimationDoneFlag = true;
                Counter = 0;
            }
        }

        public void GetFramesFromTextureProperties(int width, int height, int numberOfHeightSprites,
            int numberOfWidthSprites, int emptyFrames, int startLine)
        {
            var widthOfFrame = width / numberOfWidthSprites;
            var heightOfFrame = height / numberOfHeightSprites;

            for (var x = 0; x <= width - (widthOfFrame * (emptyFrames + 1)); x += widthOfFrame)
            {
                AddFrame(new AnimationFrame(new Rectangle(x, startLine * heightOfFrame, widthOfFrame, heightOfFrame)));
            }
        }
    }
}