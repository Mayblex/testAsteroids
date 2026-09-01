using _Asteroids.Scripts.Core.Pool;
using _Asteroids.Scripts.Data;
using _Asteroids.Scripts.Gameplay;
using _Asteroids.Scripts.Gameplay.Ship;
using _Asteroids.Scripts.Services.Assets;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Core.Factory
{
    public class UFOFactory : IFactory<UFO>
    {
        private readonly IAssetProvider _assetProvider;
        private readonly string _prefabAddress;
        private readonly Transform _target;
        private readonly CustomObjectPool<UFO> _ufoPool;
        private readonly ShipHolder _shipHolder;
        private readonly DiContainer _container;

        public UFOFactory(IAssetProvider assetProvider, string prefabAddress, int initialSize, 
            ShipHolder shipHolder, DiContainer container, GameplayStatistics gameplayStatistics)
        {
            _assetProvider = assetProvider;
            _prefabAddress = prefabAddress;
            _ufoPool = new CustomObjectPool<UFO>(this, initialSize, gameplayStatistics);
            _shipHolder = shipHolder;
            _container = container;
        }
        
        public UFO Create(Vector2 position)
        {
            var prefab = _assetProvider.GetLoadedComponent<UFO>(_prefabAddress);
            
            var instance = _container.InstantiatePrefabForComponent<UFO>(prefab, position, Quaternion.identity, null);
            var ufo = instance.GetComponent<UFO>();
            
            ufo.SetTarget(_shipHolder.Ship.transform);
            
            return instance;
        }

        public CustomObjectPool<UFO> GetPool() => _ufoPool;
    }
}