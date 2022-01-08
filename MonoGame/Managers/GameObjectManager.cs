using System.Collections.Generic;
using System.Collections.Immutable;
using MonoTest.GameObjects;
using MonoTest.Input;

namespace MonoTest.Managers
{
    public sealed class GameObjectManager
    {
        public ImmutableList<GameObject> GameObjects => _gameObjects.ToImmutableList();
        public ImmutableList<Moveable> Moveables => _moveables.ToImmutableList();
        
        private readonly List<GameObject> _gameObjects;
        private readonly List<Moveable> _moveables;

        public GameObjectManager()
        {
            _gameObjects = new List<GameObject>();
            _moveables = new List<Moveable>();
        }

        public void AddGameObject(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
            if (gameObject is Moveable moveable) _moveables.Add(moveable);
        }
    }
}