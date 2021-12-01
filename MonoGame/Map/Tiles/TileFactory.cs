using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.Map.Tiles
{
    class  BlockFactory
    {

        public static Block CreateBlock(BlockType type,int x, int y,Texture2D texture, int size)
        {

            Block newBlock = null;
            switch (type)
            {
                case BlockType.Dirt:
                    newBlock = new DirtBlock(x, y, texture, size);
                    break;
                case BlockType.GrassBlock:
                    newBlock = new GrassBlock(x, y, texture, size);
                    break;
                case BlockType.Plant:
                    newBlock = new PlantBlock(x, y, texture, size);
                    break;
                case BlockType.TopRightCorner:
                    newBlock = new TopRightCorner(x, y, texture, size);
                    break;
                case BlockType.Grass:
                    newBlock = new Grass(x, y, texture, size);
                    break; 
                case BlockType.LeftGrassBlock:
                    newBlock = new LeftGrassBlock(x, y, texture, size);
                    break; 
                case BlockType.Empty:
                    break;
            }
            return newBlock;
        }
    }

}
