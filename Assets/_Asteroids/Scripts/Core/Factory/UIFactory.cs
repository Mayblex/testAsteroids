using _Asteroids.Scripts.Services.Assets;
using _Asteroids.Scripts.UI;
using _Asteroids.Scripts.UI.Statistics;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Core.Factory
{
    public class UIFactory
    {
        private readonly RectTransform _uiRoot;
        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;
        private readonly AssetCatalogSO _catalog;
        
        public UIFactory(RectTransform uiRoot, DiContainer container, IAssetProvider assetProvider,
            AssetCatalogSO catalog)
        {
            _uiRoot = uiRoot;
            _container = container;
            _assetProvider = assetProvider;
            _catalog = catalog;
        }
        
        public WindowGameOver CreateGameOver()
        {
            var prefab = _assetProvider.GetLoadedComponent<WindowGameOver>(_catalog.WindowGameOverPrefab);
            
            return _container.InstantiatePrefabForComponent<WindowGameOver>(prefab, _uiRoot);
        }

        public StatisticsView CreateStatistics()
        {
            var prefab = _assetProvider.GetLoadedComponent<StatisticsView>(_catalog.UIStatisticsPrefab);
            
            return _container.InstantiatePrefabForComponent<StatisticsView>(prefab, _uiRoot);
        }
    }
}