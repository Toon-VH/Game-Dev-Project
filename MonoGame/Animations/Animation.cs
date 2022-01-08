using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoTest.Extensions;

namespace MonoTest.Animations
{
    public class Animation
    {
        public AnimationFrame CurrentFrame { get; private set; }
        public bool AnimationDoneFlag { get; private set; }
        private readonly List<AnimationFrame> _frames;
        private readonly List<AnimationFrame> _flippedFrames;

        public List<AnimationFrame> Frames => Flipped ? _flippedFrames : _frames;

        public int FrameCounter;
        public bool Flipped { get; private set; }
        private readonly int _frameWidth;

        private double _elapsedSeconds;

        public Animation(int frameWidth)
        {
            _frames = new List<AnimationFrame>();
            _flippedFrames = new List<AnimationFrame>();
            _frameWidth = frameWidth;
        }

        public void Update(GameTime gameTime)
        {
            AnimationDoneFlag = false;
            CurrentFrame = Frames[FrameCounter];

            _elapsedSeconds += gameTime.ElapsedGameTime.TotalSeconds;
            const int fps = 12;
            if (_elapsedSeconds >= 1.0 / fps)
            {
                FrameCounter++;
                _elapsedSeconds = 0;
            }

            if (FrameCounter >= Frames.Count)
            {
                AnimationDoneFlag = true;
                FrameCounter = 0;
            }
        }

        protected void AddHitboxes(List<List<RectangleF>> hitboxes)
        {
            for (var i = 0; i < Frames.Count; i++)
            {
                _frames[i].HitBoxes = hitboxes[i];
                _flippedFrames[i].HitBoxes = hitboxes[i].Mirror(_frameWidth);
            }
        }

        protected void AddHitboxes(int frameIndex, List<RectangleF> hitboxes)
        {
            _frames[frameIndex].HitBoxes = hitboxes;
            _flippedFrames[frameIndex].HitBoxes = hitboxes.Mirror(_frameWidth);
        }

        public void AddAttackBoxes(List<List<RectangleF>> attackBoxes)
        {
            for (var i = 0; i < Frames.Count; i++)
            {
                _frames[i].AttackBoxes = attackBoxes[i];
                _flippedFrames[i].AttackBoxes = attackBoxes[i].Mirror(_frameWidth);
            }
        }

        public void AddAttackBoxes(int frameIndex, List<RectangleF> attackBoxes)
        {
            _frames[frameIndex].AttackBoxes = attackBoxes;
            _flippedFrames[frameIndex].AttackBoxes = attackBoxes.Mirror(_frameWidth);
        }

        public void GetFramesFromTextureProperties(int width, int height, int numberOfHeightSprites,
            int numberOfWidthSprites, int emptyFrames, int startLine)
        {
            var widthOfFrame = width / numberOfWidthSprites;
            var heightOfFrame = height / numberOfHeightSprites;

            for (var x = 0; x <= width - (widthOfFrame * (emptyFrames + 1)); x += widthOfFrame)
            {
                _frames.Add(
                    new AnimationFrame(new Rectangle(x, startLine * heightOfFrame, widthOfFrame, heightOfFrame)));
                _flippedFrames.Add(new AnimationFrame(new Rectangle(x, startLine * heightOfFrame, widthOfFrame,
                    heightOfFrame)));
            }

            CurrentFrame = Frames[0];
        }

        public void SetFlip(bool flip)
        {
            if (flip != Flipped)
            {
                CurrentFrame = Frames[0];
                FrameCounter = 0;
                _elapsedSeconds = 0;
            }

            Flipped = flip;
        }
    }
}