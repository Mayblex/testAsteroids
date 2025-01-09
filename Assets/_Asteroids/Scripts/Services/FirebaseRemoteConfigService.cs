using System;
using System.Threading.Tasks;
using Firebase.Extensions;
using Firebase.RemoteConfig;
using UnityEngine;

namespace _Asteroids.Scripts.Services
{
    public class FirebaseRemoteConfigService : IRemoteConfigService
    {
        public Task Initialize()
        {
            Debug.Log("Fetching data...");
            Task fetchTask = FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
            return fetchTask.ContinueWithOnMainThread(FetchComplete);
        }

        public T GetValue<T>(string key)
        {
            string jsonString = FirebaseRemoteConfig.DefaultInstance.GetValue(key).StringValue;
            
            return JsonUtility.FromJson<T>(jsonString);
        }

        private void FetchComplete(Task fetchTask)
        {
            if (!fetchTask.IsCompleted)
            {
                Debug.LogError("Retrieval hasn't finished.");
                return;
            }

            var remoteConfig = FirebaseRemoteConfig.DefaultInstance;
            var info = remoteConfig.Info;
            if (info.LastFetchStatus != LastFetchStatus.Success)
            {
                Debug.LogError(
                    $"{nameof(FetchComplete)} was unsuccessful\n{nameof(info.LastFetchStatus)}: {info.LastFetchStatus}");
                return;
            }

            remoteConfig.ActivateAsync().ContinueWithOnMainThread(
                task => { Debug.Log($"Remote data loaded and ready for use. Last fetch time {info.FetchTime}."); });
        }
    }
}