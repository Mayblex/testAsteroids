using _Asteroids.Scripts.Gameplay.Ship;
using _Asteroids.Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.UI
{
    public class WindowGameOver : MonoBehaviour
    {
        [SerializeField] private GameObject _windowRewarded;
        [SerializeField] private GameObject _windowFinish;
        
        private IAdsService _adsService;
        private ShipHolder _shipHolder;
        private IReadonlyShip _ship;
        private bool _hasWatchedRewarded = false;

        [Inject]
        public void Construct(IAdsService adsService, ShipHolder shipHolder)
        {
            _adsService = adsService;
            _shipHolder = shipHolder;
        }

        public void Initialize()
        {
            CloseWindowRewarded();
            CloseWindowFinish();
            _ship = _shipHolder.GetReadonlyShip();
            _ship.Died += ShowWindowRewarded;
        }

        public void ShowRewardedAd()
        {
            _adsService.ShowRewardedAd();
            _hasWatchedRewarded = true;
        }

        public void GameOver()
        {
            if(!_hasWatchedRewarded)
                ShowInterstitialAd();
            ShowWindowFinish();
        }

        private void OnDestroy()
        {
            _ship.Died -= ShowWindowRewarded;
        }

        private void CloseWindowRewarded() => 
            _windowRewarded.SetActive(false);

        private void ShowWindowRewarded() => 
            _windowRewarded.SetActive(true);

        private void CloseWindowFinish() => 
            _windowFinish.SetActive(false);

        private void ShowWindowFinish() => 
            _windowFinish.SetActive(true);

        private void ShowInterstitialAd() => 
            _adsService.ShowInterstitialAd();
    }
}