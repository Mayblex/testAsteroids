using _Asteroids.Scripts.Core.Pool;
using UnityEngine;

namespace _Asteroids.Scripts.Core.Factory
{
    public class AsteroidFactory : IFactory
    {
        private readonly GameObject _prefab;
        private readonly ObjectPool _pool;
        
        public AsteroidFactory(GameObject prefab, int initialSize)
        {
            _prefab = prefab;
            _pool = new ObjectPool(this, initialSize);
        }
        
        public GameObject Create(Vector2 position)
        {
            return Object.Instantiate(_prefab, position, Quaternion.identity);
        }
        
        public ObjectPool GetPool() => _pool;
    }
}