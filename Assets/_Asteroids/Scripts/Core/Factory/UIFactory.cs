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
        private readonly WindowGameOver _gameOverPrefab;
        private readonly StatisticsView _statisticsPrefab;
        
        public UIFactory(RectTransform uiRoot, DiContainer container, WindowGameOver gameOverPrefab,
            StatisticsView statisticsPrefab)
        {
            _uiRoot = uiRoot;
            _container = container;
            _gameOverPrefab = gameOverPrefab;
            _statisticsPrefab = statisticsPrefab;
        }
        
        public WindowGameOver CreateGameOver()
            => _container.InstantiatePrefabForComponent<WindowGameOver>(_gameOverPrefab, _uiRoot);

        public StatisticsView CreateStatistics()
            => _container.InstantiatePrefabForComponent<StatisticsView>(_statisticsPrefab, _uiRoot);
    }
}