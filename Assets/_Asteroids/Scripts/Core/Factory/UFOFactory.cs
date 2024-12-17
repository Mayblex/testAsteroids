using _Asteroids.Scripts.Core.Pool;
using _Asteroids.Scripts.Gameplay;
using _Asteroids.Scripts.Gameplay.Ship;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Core.Factory
{
    public class UFOFactory : IFactory
    {
        private readonly GameObject _ufoPrefab;
        private readonly Transform _target;
        private readonly CustomObjectPool<UFO> _ufoPool;
        private readonly ShipHolder _shipHolder;
        private readonly DiContainer _container;

        public UFOFactory(GameObject ufoPrefab, int initialSize, ShipHolder shipHolder, DiContainer container)
        {
            _ufoPrefab = ufoPrefab;
            _ufoPool = new CustomObjectPool<UFO>(this, initialSize);
            _shipHolder = shipHolder;
            _container = container;
        }
        
        public GameObject Create(Vector2 position)
        {
            var instance = _container.InstantiatePrefab(_ufoPrefab, position, Quaternion.identity, null);
            var ufo = instance.GetComponent<UFO>();
            ufo.SetTarget(_shipHolder.Ship.transform);
            return instance;
        }

        public CustomObjectPool<UFO> GetPool() => _ufoPool;
    }
}