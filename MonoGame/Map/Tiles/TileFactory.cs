using Microsoft.Xna.Framework.Graphics;

namespace MonoTest.Map.Tiles
{
    class  BlockFactory
    {

        public static Tile CreateBlock(BlockType type,int x, int y,Texture2D texture, int size)
        {

            Tile newTile = null;
            switch (type)
            {
                case BlockType.Dirt:
                    newTile = new DirtTile(x, y, texture, size);
                    break;
                case BlockType.GrassBlock:
                    newTile = new GrassTile(x, y, texture, size);
                    break;
                case BlockType.Plant:
                    newTile = new PlantTile(x, y, texture, size);
                    break;
                case BlockType.TopRightCorner:
                    newTile = new TopRightCorner(x, y, texture, size);
                    break;
                case BlockType.Grass:
                    newTile = new Grass(x, y, texture, size);
                    break; 
                case BlockType.LeftGrassBlock:
                    newTile = new LeftGrassTile(x, y, texture, size);
                    break; 
                case BlockType.Empty:
                    break;
            }
            return newTile;
        }
    }

}
