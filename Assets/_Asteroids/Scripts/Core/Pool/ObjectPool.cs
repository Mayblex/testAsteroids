using _Asteroids.Scripts.Core.Factory;
using UnityEngine;
using UnityEngine.Pool;

namespace _Asteroids.Scripts.Core.Pool
{
    public class ObjectPool
    {
        private ObjectPool<GameObject> _pool;

        private IFactory _factory;
        private Vector2 _position;

        public ObjectPool(IFactory factory, int initialSize)
        {
            _factory = factory;
            _pool = new ObjectPool<GameObject>(OnCreateObject, OnGetObject, OnRelease, OnObjectDestroy, false,
                initialSize);
        }

        public GameObject Get()
        {
            var obj = _pool.Get();
            return obj;
        }

        private void Release(GameObject obj)
        {
            _pool.Release(obj);
        }

        private void OnObjectDestroy(GameObject obj)
        {
            if (obj.TryGetComponent<IPoolable>(out IPoolable poolable))
                poolable.Released -= Release;
            
            Object.Destroy(obj);
        }

        private void OnRelease(GameObject obj) => 
            obj.gameObject.SetActive(false);

        private void OnGetObject(GameObject obj) => 
            obj.gameObject.SetActive(true);

        private GameObject OnCreateObject()
        {
            GameObject obj = _factory.Create(_position);

            if (obj.TryGetComponent<IPoolable>(out IPoolable poolable))
                poolable.Released += Release;
            
            return obj;
        }
    }
}