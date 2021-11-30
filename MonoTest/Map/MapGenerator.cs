using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.Tiles;

namespace MonoTest.Map
{
    public class MapGenerator
    {
        private List<Block> blocks;
        private Texture2D _tiles;
        private int _sizeBlock;
        private int[,] _map;

        public MapGenerator(Texture2D tiles, int[,] map, int sizeBlock, List<IGameObject> gameObjects)
        {
            _sizeBlock = sizeBlock;
            _map = map;
            blocks = new List<Block>();
            _tiles = tiles;
            CreateBlocks();
        }

        private void CreateBlocks()
        {
            for (var y = 0; y < _map.GetLength(0); y++)
            {
                for (var x = 0; x < _map.GetLength(1); x++)
                {
                    blocks.Add(BlockFactory.CreateBlock((BlockType) _map[y, x], x, y, _tiles, _sizeBlock));
                }
            }
        }
    }
}