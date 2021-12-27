using System.Linq;
using Microsoft.Xna.Framework;
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
        private readonly int _sizeBlock;
        private readonly int[,] _tiles;
        private readonly GameObjectConfig[] _gameObjectConfigs;
        

        public MapGenerator(int[,] tiles, GameObjectConfig[] gameObjectConfigs, int sizeBlock)
        {
            _sizeBlock = sizeBlock;
            _gameObjectConfigs = gameObjectConfigs;
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

        public void InitializePlants(Texture2D plantTexture, Texture2D gorillaTexture, GameObjectManager gameObjectManager, SoundEffect gorillaRoar)
        {
            if (_gameObjectConfigs.Any())
            {
                foreach (var goc in _gameObjectConfigs)
                {
                    switch (goc)
                    {
                        case PlantConfig plant: gameObjectManager.AddGameObject(new Plant((int)plant.Position.X * _sizeBlock - _sizeBlock/2, (int)plant.Position.Y * _sizeBlock, plantTexture, plant.PlantType, plant.AttackSpeed));
                            break;
                        case GorillaConfig gorilla:
                            gameObjectManager.AddGameObject(new Gorilla(gorillaTexture, gorillaRoar)
                            {
                                Position = gorilla.Position * _sizeBlock
                            });
                            break;
                            
                    }
                }  
            }
        }
    }
}