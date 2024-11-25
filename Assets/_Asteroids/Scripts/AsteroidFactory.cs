using UnityEngine;
using UnityEngine.Pool;

namespace Scripts
{
    public class AsteroidFactory : IFactory
    {
        private const string Path = "Prefabs/Asteroid";

        private readonly GameObject _asteroidPrefab;

        public AsteroidFactory(GameObject asteroidPrefab)
        {
            _asteroidPrefab = asteroidPrefab;
        }
        
        public GameObject Create(Vector2 position)
        {
            return Object.Instantiate(_asteroidPrefab, position, Quaternion.identity);
        }

        // private GameObject Instantiate(string path, Vector2 position)
        // {
        //     var prefab = Resources.Load<GameObject>(path);
        //     return Object.Instantiate(prefab, position, Quaternion.identity);
        // }
    }
}