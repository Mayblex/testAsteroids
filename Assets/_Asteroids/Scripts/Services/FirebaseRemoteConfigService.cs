using System;
using Cysharp.Threading.Tasks;
using Firebase.RemoteConfig;
using UnityEngine;

namespace _Asteroids.Scripts.Services
{
    public class FirebaseRemoteConfigService : IRemoteConfigService
    {
        public async UniTask Initialize()
        {
            Debug.Log("Fetching data...");
            await FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
            await FetchComplete();
        }

        public T GetValue<T>(string key)
        {
            string jsonString = FirebaseRemoteConfig.DefaultInstance.GetValue(key).StringValue;
            
            return JsonUtility.FromJson<T>(jsonString);
        }

        private async UniTask FetchComplete()
        {
            var remoteConfig = FirebaseRemoteConfig.DefaultInstance;
            var info = remoteConfig.Info;
            if (info.LastFetchStatus != LastFetchStatus.Success)
            {
                Debug.LogError(
                    $"{nameof(FetchComplete)} was unsuccessful\n{nameof(info.LastFetchStatus)}: {info.LastFetchStatus}");
                return;
            }

            await remoteConfig.ActivateAsync();
            Debug.Log($"Remote data loaded and ready for use. Last fetch time {info.FetchTime}.");
        }
    }
}