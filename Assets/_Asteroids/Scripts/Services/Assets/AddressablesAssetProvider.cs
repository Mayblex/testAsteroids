using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace _Asteroids.Scripts.Services.Assets
{
    public class AddressablesAssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _cache = new();
        
        public async UniTask<T> LoadAssetAsync<T>(string address) where T : Object
        {
            if (_cache.TryGetValue(address, out var existing))
                return existing.Result as T;
            
            var handle = Addressables.LoadAssetAsync<T>(address);
            _cache[address] = handle;

            return await handle.ToUniTask();
        }

        public async UniTask Warmup(params string[] addresses)
        {
            var tasks = new UniTask[addresses.Length];

            for (int i = 0; i < addresses.Length; i++)
            {
                tasks[i] = LoadAssetAsync<GameObject>(addresses[i]);
            }
            
            await UniTask.WhenAll(tasks);
        }

        public T GetLoadedComponent<T>(string address) where T : Component
        {
            var prefab = (GameObject)_cache[address].Result;
            
            return prefab.GetComponent<T>();
        }

        public void Release(string address)
        {
            if (_cache.TryGetValue(address, out var handle))
            {
                Addressables.Release(handle);
                _cache.Remove(address);
            }
        }

        public void ReleaseAll()
        {
            foreach (var kv in _cache)
                Addressables.Release(kv.Value);
            
            _cache.Clear();
        }
    }
}