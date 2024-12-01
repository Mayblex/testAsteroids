using UnityEngine;
using UnityEngine.Pool;

namespace Scripts
{
    public class AsteroidFactory : IFactory
    {
        private readonly GameObject _asteroidPrefab;

        public AsteroidFactory(GameObject asteroidPrefab)
        {
            _asteroidPrefab = asteroidPrefab;
        }
        
        public GameObject Create(Vector2 position)
        {
            return Object.Instantiate(_asteroidPrefab, position, Quaternion.identity);
        }
    }
}