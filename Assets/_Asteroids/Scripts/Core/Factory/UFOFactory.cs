using _Asteroids.Scripts.Core.Pool;
using _Asteroids.Scripts.Gameplay;
using UnityEngine;

namespace _Asteroids.Scripts.Core.Factory
{
    public class UFOFactory : IFactory
    {
        private readonly GameObject _ufoPrefab;
        private readonly Transform _target;
        private readonly ObjectPool _ufoPool;

        public UFOFactory(GameObject ufoPrefab, int initialSize,Transform target)
        {
            _ufoPrefab = ufoPrefab;
            _ufoPool = new ObjectPool(this, initialSize);
            _target = target;
        }
        
        public GameObject Create(Vector2 position)
        {
            var instance = Object.Instantiate(_ufoPrefab, position, Quaternion.identity);
            var ufo = instance.GetComponent<UFO>();
            ufo.SetTarget(_target);
            return instance;
        }

        public ObjectPool GetPool() => _ufoPool;
    }
}