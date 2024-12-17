using _Asteroids.Scripts.Core.Pool;
using _Asteroids.Scripts.Gameplay.Asteroids;
using UnityEngine;

namespace _Asteroids.Scripts.Core.Factory
{
    public class AsteroidFactory : IFactory
    {
        private readonly GameObject _prefab;
        private readonly CustomObjectPool<AsteroidBase> _pool;
        
        public AsteroidFactory(GameObject prefab, int initialSize)
        {
            _prefab = prefab;
            _pool = new CustomObjectPool<AsteroidBase>(this, initialSize);
        }
        
        public GameObject Create(Vector2 position)
        {
            return Object.Instantiate(_prefab, position, Quaternion.identity);
        }
        
        public CustomObjectPool<AsteroidBase> GetPool() => _pool;
    }
}