using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using MonoTest.GameObjects;
using MonoTest.GameObjects.Plants;
using MonoTest.Managers;
using MonoTest.Map.ObjectConfig;
using MonoTest.Map.Tiles;

namespace MonoTest.Map
{
    public class MapGenerator
    {
        private readonly int _blockSize;
        private readonly int[,] _tiles;
        private readonly GameObjectConfig[] _gameObjectConfigs;


        public MapGenerator(int[,] tiles, GameObjectConfig[] gameObjectConfigs, int blockSize)
        {
            _blockSize = blockSize;
            _gameObjectConfigs = gameObjectConfigs;
            _tiles = tiles;
        }

        public void InitializeBlocks(Texture2D texture, GameObjectManager gameObjectManager)
        {
            Debug.WriteLine(_tiles.GetLength(0));
            Debug.WriteLine(_tiles.GetLength(1));
            for (var y = 0; y < _tiles.GetLength(0); y++)
            {
                for (var x = 0; x < _tiles.GetLength(1); x++)
                {
                    gameObjectManager.AddGameObject(BlockFactory.CreateBlock(_tiles[y, x], x, y, texture,
                        _blockSize));
                }
            }
        }

        public void InitializePlants(Texture2D plantTexture, Texture2D gorillaTexture,
            GameObjectManager gameObjectManager, SoundEffect gorillaRoar)
        {
            if (_gameObjectConfigs.Any())
            {
                foreach (var goc in _gameObjectConfigs)
                {
                    switch (goc)
                    {
                        case PlantConfig plant:
                            gameObjectManager.AddGameObject(new Plant(
                                (int)(plant.Position.X + 1) * _blockSize - _blockSize / 2,
                                (int)plant.Position.Y * _blockSize, plantTexture, plant.PlantType, plant.AttackSpeed));
                            break;
                        case GorillaConfig gorilla:
                            gameObjectManager.AddGameObject(new Gorilla(gorillaTexture, gorillaRoar)
                            {
                                Position = gorilla.Position * _blockSize
                            });
                            break;
                    }
                }
            }
        }
    }
}