using _Asteroids.Scripts.Core.Factory;
using _Asteroids.Scripts.UI;
using _Asteroids.Scripts.UI.Statistics;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private RectTransform _uiRoot;
        [SerializeField] private StatisticsView _uiStatisticsPrefab;
        [SerializeField] private WindowGameOver _uiGameOverPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<UIFactory>()
                .AsSingle()
                .WithArguments(_uiRoot, Container, _uiGameOverPrefab, _uiStatisticsPrefab);

            Container.Bind<StatisticsPresenter>().AsSingle();
        }
    }
}