﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest
{
    class Animation
    {
        private Double secondCounter = 0;
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter;

        public Animation()
        {
            frames = new List<AnimationFrame>();
        }
        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 15;
            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }

        }

        public void GetFramesFromTextureProperties(int width, int height, int numberOfHeightSprites, int numberOfWidthSprites, int emptyFrames,int startLine)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;

            for (int x = 0; x <= width - (widthOfFrame * (emptyFrames + 1)); x += widthOfFrame)
            {
                frames.Add(new AnimationFrame(new Rectangle(x, startLine * heightOfFrame, widthOfFrame, heightOfFrame)));
            }
        }
    }
}
