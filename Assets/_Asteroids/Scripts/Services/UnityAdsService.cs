using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Advertisements;

namespace _Asteroids.Scripts.Services
{
    public class UnityAdsService : IAdsService, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        public event Action OnRewardedAdCompleted = delegate { };
        
        private const string ANDROID_GAME_ID = "5796925";
        private const string TEST_GAME_ID = "1234567";
        private const string REWARDED_AD = "Rewarded_Android";
        private const string INTERSTITIAL_AD = "Interstitial_Android";
        private bool _testMode = true;
        private string _gameId;

        public async Task Initialize()
        {
#if UNITY_ANDROID
            _gameId = _androidGameId;
#elif UNITY_EDITOR
            _gameId = TEST_GAME_ID;
#endif
            if (!Advertisement.isInitialized && Advertisement.isSupported)
            {
                Advertisement.Initialize(_gameId, _testMode);
            }
            
            LoadRewardedAd();
            LoadInterstitialAd();
        }

        public void LoadRewardedAd() => 
            Advertisement.Load(REWARDED_AD, this);

        public void LoadInterstitialAd() => 
            Advertisement.Load(INTERSTITIAL_AD, this);

        public void ShowRewardedAd()
        {
            Advertisement.Show(REWARDED_AD, this);
        }

        public void ShowInterstitialAd() => 
            Advertisement.Show(INTERSTITIAL_AD, this);

        public void OnUnityAdsAdLoaded(string adUnitId)
        {
            Debug.Log("Ad loaded: " + adUnitId);
        }

        public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
        {
            Debug.LogError($"Failed to load Ad Unit {adUnitId}: {error} - {message}");
        }
        
        public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
        {
            Debug.LogError($"Error showing Ad Unit {adUnitId}: {error} - {message}");
        }

        public void OnUnityAdsShowStart(string adUnitId)
        {
            Debug.Log("Ad started: " + adUnitId);
        }

        public void OnUnityAdsShowClick(string adUnitId)
        {
            Debug.Log("Ad clicked: " + adUnitId);
        }

        public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
        {
            Debug.Log($"Ad completed: {adUnitId} with state: {showCompletionState}");
            if (adUnitId.Equals(REWARDED_AD) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
            {
                OnRewardedAdCompleted?.Invoke();
            }
        }
    }
}