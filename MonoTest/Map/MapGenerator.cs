using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.GameObjects;
using MonoTest.Map.Tiles;

namespace MonoTest.Map
{
    public class MapGenerator
    {
        private int _sizeBlock;
        private int[,] _map;

        public MapGenerator(int[,] map, int sizeBlock)
        {
            _sizeBlock = sizeBlock;
            _map = map;
        }

        public void InitializeBlocks(Texture2D tiles, List<IGameObject> gameObjects)
        {
            for (var y = 0; y < _map.GetLength(0); y++)
            {
                for (var x = 0; x < _map.GetLength(1); x++)
                {
                    gameObjects.Add(BlockFactory.CreateBlock((BlockType) _map[y, x], x, y, tiles, _sizeBlock));
                }
            }
        }
    }
}