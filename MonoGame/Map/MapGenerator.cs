using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.GameObjects;
using MonoTest.Managers;
using MonoTest.Map.Plants;
using MonoTest.Map.Tiles;

namespace MonoTest.Map
{
    public class MapGenerator
    {
        private readonly int _sizeBlock;
        private readonly int[,] _tiles;
        private readonly PlantConfig[] _plants;

        public MapGenerator(int[,] tiles, PlantConfig[] plants, int sizeBlock)
        {
            _sizeBlock = sizeBlock;
            _plants = plants;
            _tiles = tiles;
        }

        public void InitializeBlocks(Texture2D texture, GameObjectManager gameObjectManager)
        {
            for (var y = 0; y < _tiles.GetLength(0); y++)
            {
                for (var x = 0; x < _tiles.GetLength(1); x++)
                {
                    gameObjectManager.AddGameObject(BlockFactory.CreateBlock((BlockType)_tiles[y, x], x, y, texture,
                        _sizeBlock));
                }
            }
        }

        public void InitializePlants(Texture2D texture, GameObjectManager gameObjectManager)
        {
            foreach (var plant in _plants)
            {
                gameObjectManager.AddGameObject(new Plant((int)plant.Position.X * _sizeBlock,
                    (int)plant.Position.Y * _sizeBlock, texture, plant.PlantType,
                    plant.AttackSpeed));
            }
        }
    }
}