using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTest.Tiles
{
    class BlockFactory
    {

        public static Block CreateBlock(BlockType type,int x, int y,Texture2D texture, int size)
        {

            Block newBlock = null;
            switch (type)
            {
                case BlockType.DIRT:
                    newBlock = new DirtBlock(x, y, texture, size);
                    break;
                case BlockType.GRASS:
                    newBlock = new GrassBlock(x, y, texture, size);
                    break;
                case BlockType.EMPTY:
                    break;
            }
            return newBlock;
        }
    }

}
