using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest.Tiles
{
    class BlockFactory
    {

        public static Block CreateBlock(string type, int x, int y,Texture2D texture )//GraphicsDevice graphics)
        {

            Block newBlock = null;
            type = type.ToUpper();
            if (type == "NORMAL")
            {
                newBlock = new Block(x, y, texture);
            }
            if (type == "GRASS")
            {
                newBlock = new GrassBlock(x, y, texture);
            }
            /*if (type == "LeftCorner")
            {
                newBlock = new LeftCorner(x, y, graphics);
            }*/
            return newBlock;
        }
    }

    }
