using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Core.Factory
{
    public class CommonFactory : IFactory
    {
        private readonly GameObject _prefab;
        private readonly DiContainer _container;
        
        public CommonFactory(GameObject prefab, DiContainer container)
        {
            _prefab = prefab;
            _container = container;
        }
        
        public GameObject Create(Vector2 position)
        {
            var instance = _container.InstantiatePrefab(_prefab, position, Quaternion.identity, null);
            
            _container.Inject(instance);
            
            return instance;
        }
    }
}