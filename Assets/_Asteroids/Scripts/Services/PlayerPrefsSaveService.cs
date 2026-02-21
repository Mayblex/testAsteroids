using _Asteroids.Scripts.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;
using System;

namespace _Asteroids.Scripts.Services
{
    public class PlayerPrefsSaveService : ISaveService
    {
        private const string KEY = "player_save";
        
        public SaveData Load()
        {
            if (!HasSave())
            {
                return CreateDefault();
            }
            
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

        public bool HasSave() => PlayerPrefs.HasKey(KEY);

        public void Clear()
        {
            PlayerPrefs.DeleteKey(KEY);
            PlayerPrefs.Save();
        }

        private static SaveData CreateDefault() =>
            new SaveData { SaveAtUnix = NowUnix() };
        
        private static long NowUnix() => DateTimeOffset.Now.ToUnixTimeSeconds();
    }
}