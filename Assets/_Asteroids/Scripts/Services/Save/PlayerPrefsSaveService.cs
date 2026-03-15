using System;
using _Asteroids.Scripts.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Asteroids.Scripts.Services.Save
{
    public class PlayerPrefsSaveService : ISaveService
    {
        private const string KEY = "player_save";
        
        public SaveData Load()
        {
            var json = PlayerPrefs.GetString(KEY, string.Empty);

            if (string.IsNullOrEmpty(json))
                return CreateDefault();
            
            var data = JsonUtility.FromJson<SaveData>(json);

            if (data == null)
                return CreateDefault();
            
            return data;
        }

        public UniTask Save(SaveData data)
        {
            data.SaveAtUnix = NowUnix();
            var json = JsonUtility.ToJson(data);
            
            PlayerPrefs.SetString(KEY, json);
            PlayerPrefs.Save();
            
            return UniTask.CompletedTask;
        }

        public void Clear()
        {
            PlayerPrefs.DeleteKey(KEY);
            PlayerPrefs.Save();
        }

        private static SaveData CreateDefault() =>
            new SaveData { SaveAtUnix = NowUnix() };
        
        private static long NowUnix() => DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
}