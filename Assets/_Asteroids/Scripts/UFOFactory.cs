using UnityEngine;

namespace Scripts
{
    public class UFOFactory : IFactory
    {
        private readonly GameObject _ufoPrefab;
        
        private readonly Transform _target;
        
        public UFOFactory(GameObject ufoPrefab, Transform target)
        {
            _ufoPrefab = ufoPrefab;
            _target = target;
        }
        
        public GameObject Create(Vector2 position)
        {
            var instance = Object.Instantiate(_ufoPrefab, position, Quaternion.identity);
            var ufo = instance.GetComponent<UFO>();
            ufo.SetTarget(_target);
            return instance;
        }
    }
}