using System;
using System.Threading.Tasks;

namespace _Asteroids.Scripts.Services
{
    public interface IAdsService
    {
        event Action OnRewardedAdCompleted;
        
        Task Initialize();
        void LoadRewardedAd();
        void ShowRewardedAd();
        void LoadInterstitialAd();
        void ShowInterstitialAd();
    }
}