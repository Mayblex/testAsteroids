using _Asteroids.Scripts.Gameplay.Ship;
using _Asteroids.Scripts.Services.Assets;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Core.Factory
{
    public class ShipFactory : IFactory<Ship>
    {
        private readonly IAssetProvider _assetProvider;
        private readonly string _prefabAddress;
        private readonly ShipHolder _shipHolder;
        private readonly DiContainer _container;
        
        public ShipFactory(IAssetProvider assetProvider, string prefabAddress, ShipHolder shipHolder, DiContainer container)
        {
            _assetProvider = assetProvider;
            _prefabAddress = prefabAddress;
            _shipHolder = shipHolder;
            _container = container;
        }
        
        public Ship Create(Vector2 position)
        {
            var prefab = _assetProvider.GetLoadedComponent<Ship>(_prefabAddress);
            var instance = _container.InstantiatePrefabForComponent<Ship>(prefab, position, Quaternion.identity, null);
            
            _container.Inject(instance);
            _shipHolder.SetShip(instance);
            
            return instance;
        }
    }
}