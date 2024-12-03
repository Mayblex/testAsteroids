using UnityEngine;

namespace _Asteroids.Scripts.Core.Factory
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