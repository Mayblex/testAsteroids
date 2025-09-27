using _Asteroids.Scripts.Core.Pool;
using _Asteroids.Scripts.Data;
using _Asteroids.Scripts.Gameplay.Asteroids;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Core.Factory
{
    public class AsteroidFactory : IFactory<AsteroidBase>
    {
        private readonly GameObject _prefab;
        private readonly CustomObjectPool<AsteroidBase> _pool;
        private readonly DiContainer _container;

        public AsteroidFactory(GameObject prefab, int initialSize, DiContainer container, GameplayStatistics gameplayStatistics)
        {
            _prefab = prefab;
            _pool = new CustomObjectPool<AsteroidBase>(this, initialSize, gameplayStatistics);
            _container = container;
        }
        
        public AsteroidBase Create(Vector2 position)
        {
            return _container.InstantiatePrefabForComponent<AsteroidBase>(_prefab, position, Quaternion.identity, null);
        }
        
        public CustomObjectPool<AsteroidBase> GetPool() => _pool;
    }
}