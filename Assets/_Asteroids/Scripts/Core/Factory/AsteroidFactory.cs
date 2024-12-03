using _Asteroids.Scripts.Core.Pool;
using UnityEngine;

namespace _Asteroids.Scripts.Core.Factory
{
    public class AsteroidFactory : IFactory
    {
        private readonly GameObject _asteroidPrefab;
        private readonly ObjectPool _asteroidPool;


        public AsteroidFactory(GameObject asteroidPrefab, int initialSize)
        {
            _asteroidPrefab = asteroidPrefab;
            _asteroidPool = new ObjectPool(this, initialSize);
        }
        
        public GameObject Create(Vector2 position)
        {
            return Object.Instantiate(_asteroidPrefab, position, Quaternion.identity);
        }
        
        public ObjectPool GetPool() => _asteroidPool;
    }
}