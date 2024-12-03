using UnityEngine;

namespace _Asteroids.Scripts.Core.Factory
{
    public class CommonFactory : IFactory
    {
        private readonly GameObject _prefab;
        
        public CommonFactory(GameObject prefab)
        {
            _prefab = prefab;
        }
        
        public GameObject Create(Vector2 position)
        {
            return Object.Instantiate(_prefab, position, Quaternion.identity);
        }
    }
}