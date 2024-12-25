using _Asteroids.Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Core
{
    public class Bootstrap : IInitializable
    {
        private readonly ZenjectSceneLoader _sceneLoader;
        private readonly IAnalyticsService _analyticsService;
        
        public Bootstrap(ZenjectSceneLoader sceneLoader, IAnalyticsService analyticsService)
        {
            _sceneLoader = sceneLoader;
            _analyticsService = analyticsService;
        }
        
        public async void Initialize()
        {
            Debug.Log("Start");
            
            await _analyticsService.Initialize();
            
            _sceneLoader.LoadScene("MainScene");
        }
    }
}