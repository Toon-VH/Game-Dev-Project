using System.Collections.Generic;
using System.Collections.Immutable;
using MonoTest.GameObjects;
using MonoTest.Input;

namespace MonoTest.Managers
{
    public sealed class GameObjectManager
    {
        public ImmutableList<IGameObject> GameObjects => _gameObjects.ToImmutableList();
        public ImmutableList<Moveable> Moveables => _moveables.ToImmutableList();
        
        private readonly List<IGameObject> _gameObjects;
        private readonly List<Moveable> _moveables;

        public GameObjectManager()
        {
            _gameObjects = new List<IGameObject>();
            _moveables = new List<Moveable>();
        }

        public void AddGameObject(IGameObject gameObject)
        {
            _gameObjects.Add(gameObject);
            if (gameObject is Moveable moveable) _moveables.Add(moveable);
        }
    }
}