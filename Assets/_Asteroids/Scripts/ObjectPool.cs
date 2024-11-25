using UnityEngine;
using UnityEngine.Pool;

namespace Scripts
{
    public class ObjectPool
    {
        private ObjectPool<GameObject> _pool;

        private GameObject _prefab;

        public ObjectPool(GameObject prefab, int prewarmObjectsCount)
        {
            _prefab = prefab;
            _pool = new ObjectPool<GameObject>(OnCreateObject, OnGetObject, OnRelease, OnObjectDestroy, false,
                prewarmObjectsCount);
        }

        public GameObject Get()
        {
            var obj = _pool.Get();
            return obj;
        }
        
        public void Release(GameObject obj)
        {
            _pool.Release(obj);
        }
        
        private void OnObjectDestroy(GameObject obj)
        {
            GameObject.Destroy(obj);
        }
        
        private void OnRelease(GameObject obj) => 
            obj.gameObject.SetActive(false);

        private void OnGetObject(GameObject obj) => 
            obj.gameObject.SetActive(true);

        private GameObject OnCreateObject() => 
            Object.Instantiate(_prefab);
    }
}