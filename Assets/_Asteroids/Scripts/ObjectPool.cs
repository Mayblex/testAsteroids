using UnityEngine;
using UnityEngine.Pool;

namespace Scripts
{
    public class ObjectPool
    {
        private ObjectPool<GameObject> _pool;

        private IFactory _factory;
        private Vector2 _position;

        public ObjectPool(IFactory factory, int prewarmObjectsCount, Vector2 position)
        {
            _factory = factory;
            _pool = new ObjectPool<GameObject>(OnCreateObject, OnGetObject, OnRelease, OnObjectDestroy, false,
                prewarmObjectsCount);
            _position = position;
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

        private GameObject OnCreateObject()
        {
            return _factory.Create(_position);
        }
    }
}