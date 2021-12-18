using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace MonoTest.Animations
{
    public class Animation
    {
        private Double _secondCounter = 0;
        public AnimationFrame CurrentFrame { get; set; }
        public RectangleF CurrentHitbox { get; set; }
        private List<AnimationFrame> _frames;
        private List<RectangleF> _hitboxes;
        private int _counter;

        public Animation()
        {
            _frames = new List<AnimationFrame>();
            _hitboxes = new List<RectangleF>();
        }

        public void AddFrame(AnimationFrame frame)
        {
            _frames.Add(frame);
            CurrentFrame = _frames[0];
        }

        public void AddHitboxList(List<RectangleF> hitboxes)
        {
            _hitboxes = hitboxes;
            CurrentHitbox = _hitboxes[0];
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = _frames[_counter];
            CurrentHitbox = _hitboxes[_counter];
            _secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            var fps = 12;
            if (_secondCounter >= 1d / fps)
            {
                _counter++;
                _secondCounter = 0;
            }

            if (_counter >= _frames.Count)
            {
                _counter = 0;
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