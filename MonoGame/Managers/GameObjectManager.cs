using System.Collections.Generic;
using System.Collections.Immutable;
using MonoTest.GameObjects;

namespace MonoTest.Managers
{
    public sealed class GameObjectManager
    {
        public ImmutableList<GameObject> GameObjects => _gameObjects.ToImmutableList();
        public ImmutableList<Moveable> Moveables => _moveables.ToImmutableList();

        public ImmutableList<List<GameObject>> ChunkedGameObjects => _chunkedGameObjects.ToImmutableList();
        public ImmutableList<List<Moveable>> ChunkedMoveables => _chunkedMoveables.ToImmutableList();

        private readonly List<GameObject> _gameObjects;
        private readonly List<Moveable> _moveables;

        private readonly List<GameObject>[] _chunkedGameObjects;
        private readonly List<Moveable>[] _chunkedMoveables;

        public GameObjectManager()
        {
            _gameObjects = new List<GameObject>();
            _moveables = new List<Moveable>();
            _chunkedGameObjects = new List<GameObject>[100];
            _chunkedMoveables = new List<Moveable>[100];
        }

        public void AddGameObject(GameObject gameObject, int? chunk = null)
        {
            Moveable moveable = null;
            if (gameObject is Moveable mov) moveable = mov;
            
            if (chunk is null)
            {
                _gameObjects.Add(gameObject);
                if (moveable is not null) _moveables.Add(moveable);
                return;
            }

            _chunkedGameObjects[chunk.Value] ??= new List<GameObject>();
            _chunkedGameObjects[chunk.Value].Add(gameObject);
            if (moveable is not null)
            {
                _chunkedMoveables[chunk.Value] ??= new List<Moveable>();
                _chunkedMoveables[chunk.Value].Add(moveable);
            }
        }

        public void RemoveGameObject(GameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
            if (gameObject is Moveable moveable) _moveables.Remove(moveable);
        }
    }
}