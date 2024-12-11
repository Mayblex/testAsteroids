using _Asteroids.Scripts.Gameplay.Ship;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Core.Factory
{
    public class ShipFactory : IFactory
    {
        private readonly GameObject _prefab;
        private readonly ShipHolder _shipHolder;
        private readonly DiContainer _container;
        
        public ShipFactory(GameObject prefab, ShipHolder shipHolder, DiContainer container)
        {
            _prefab = prefab;
            _shipHolder = shipHolder;
            _container = container;
        }
        
        public GameObject Create(Vector2 position)
        {
            var instance = _container.InstantiatePrefab(_prefab, position, Quaternion.identity, null);
            
            _container.Inject(instance);
            _shipHolder.SetShip(instance);
            
            return instance;
        }
    }
}