using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.GameObjects;
using MonoTest.Managers;
using MonoTest.Map.Tiles;

namespace MonoTest.Map
{
    public class MapGenerator
    {
        private readonly int _sizeBlock;
        private readonly int[,] _map;

        public MapGenerator(int[,] map, int sizeBlock)
        {
            _sizeBlock = sizeBlock;
            _map = map;
        }

        public void InitializeBlocks(Texture2D tiles, GameObjectManager gameObjectManager)
        {
            for (var y = 0; y < _map.GetLength(0); y++)
            {
                for (var x = 0; x < _map.GetLength(1); x++)
                {
                    gameObjectManager.AddGameObject(BlockFactory.CreateBlock((BlockType) _map[y, x], x, y, tiles, _sizeBlock));
                }
            }
        }
    }
}