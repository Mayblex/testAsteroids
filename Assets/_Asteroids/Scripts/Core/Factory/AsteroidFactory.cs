using _Asteroids.Scripts.Core.Pool;
using _Asteroids.Scripts.Data;
using _Asteroids.Scripts.Gameplay.Asteroids;
using _Asteroids.Scripts.Services.Assets;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Core.Factory
{
    public class AsteroidFactory : IFactory<AsteroidBase>
    {
        private readonly IAssetProvider _assetProvider;
        private readonly string _prefabAddress;
        private readonly CustomObjectPool<AsteroidBase> _pool;
        private readonly DiContainer _container;

        public AsteroidFactory(IAssetProvider assetProvider, string prefabAddress, int initialSize, 
            DiContainer container, GameplayStatistics gameplayStatistics)
        {
            _assetProvider = assetProvider;
            _prefabAddress = prefabAddress;
            _pool = new CustomObjectPool<AsteroidBase>(this, initialSize, gameplayStatistics);
            _container = container;
        }
        
        public AsteroidBase Create(Vector2 position)
        {
            var prefab = _assetProvider.GetLoaded<GameObject>(_prefabAddress);
            
            return _container.InstantiatePrefabForComponent<AsteroidBase>(prefab, position, Quaternion.identity, null);
        }
        
        public CustomObjectPool<AsteroidBase> GetPool() => _pool;
    }
}