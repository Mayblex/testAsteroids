using _Asteroids.Scripts.Core.Pool;
using _Asteroids.Scripts.Gameplay.Asteroids;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Core.Factory
{
    public class AsteroidFactory : IFactory
    {
        private readonly GameObject _prefab;
        private readonly CustomObjectPool<AsteroidBase> _pool;
        private readonly DiContainer _container;

        public AsteroidFactory(GameObject prefab, int initialSize, DiContainer container)
        {
            _prefab = prefab;
            _pool = new CustomObjectPool<AsteroidBase>(this, initialSize);
            _container = container;
        }
        
        public GameObject Create(Vector2 position)
        {
            return _container.InstantiatePrefab(_prefab, position, Quaternion.identity, null);
        }
        
        public CustomObjectPool<AsteroidBase> GetPool() => _pool;
    }
}