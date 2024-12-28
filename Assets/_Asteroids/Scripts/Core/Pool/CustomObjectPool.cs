using _Asteroids.Scripts.Core.Factory;
using _Asteroids.Scripts.Data;
using _Asteroids.Scripts.Gameplay;
using _Asteroids.Scripts.Gameplay.Asteroids;
using UnityEngine;
using UnityEngine.Pool;

namespace _Asteroids.Scripts.Core.Pool
{
    public class CustomObjectPool<T> where T : Component
    {
        private readonly ObjectPool<T> _pool;
        private readonly IFactory _factory;
        private readonly GameplayStatistics _gameplayStatistics;
        private Vector2 _position;

        public CustomObjectPool(IFactory factory, int initialSize, GameplayStatistics gameplayStatistics)
        {
            _factory = factory;
            _pool = new ObjectPool<T>(OnCreateObject, OnGetObject, OnRelease, OnObjectDestroy, false,
                initialSize);
            _gameplayStatistics = gameplayStatistics;
        }

        public T Get()
        {
            var obj = _pool.Get();
            return obj;
        }

        private void Release(T obj)
        {
            _pool.Release(obj);
        }

        private void OnObjectDestroy(T obj)
        {
            if (obj.TryGetComponent<IPoolable>(out IPoolable poolable))
                poolable.Released -= OnReleaseEvent;
            
            Object.Destroy(obj);
        }

        private void OnRelease(T obj) => 
            obj.gameObject.SetActive(false);

        private void OnGetObject(T obj) => 
            obj.gameObject.SetActive(true);

        private T OnCreateObject()
        {
            GameObject obj = _factory.Create(_position);

            T component = obj.GetComponent<T>();

            if (obj.TryGetComponent<IPoolable>(out IPoolable poolable))
                poolable.Released += OnReleaseEvent;
            
            return component;
        }

        private void OnReleaseEvent(GameObject obj)
        {
            if (obj.TryGetComponent<T>(out T component))
            {
                Release(component);

                if(obj.GetComponent<AsteroidBase>())
                    _gameplayStatistics.IncrementDestroyedAsteroids();
                if (obj.GetComponent<UFO>())
                    _gameplayStatistics.IncrementDestroyedUFOs();
            }
        }
    }
}