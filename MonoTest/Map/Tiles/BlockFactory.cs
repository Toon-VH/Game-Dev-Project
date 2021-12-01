using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.Map.Tiles
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
                case BlockType.PLANT:
                    newBlock = new PlantBlock(x, y, texture, size);
                    break;
                case BlockType.EMPTY:
                    break;
            }
            return newBlock;
        }
    }

}
