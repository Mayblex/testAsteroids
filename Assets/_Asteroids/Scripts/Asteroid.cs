using System;
using UnityEngine;
using Random = System.Random;

namespace Scripts
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private GameObject _fragmentAsteroidPrefab;

        private Random _random;
        private Vector3 _direction = Vector3.zero;
        
        private void Awake()
        {
            _random = new Random();
            SetRandomDirection();
        }

        public void FixedUpdate()
        {
            transform.Translate(_direction * _speed * Time.fixedDeltaTime);
        }

        private void OnDestroy()
        {
            CreateFragment(2);
        }

        private void CreateFragment(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Instantiate(_fragmentAsteroidPrefab, transform.position, transform.rotation);
            }
        }

        private void SetRandomDirection()
        {
            while(_direction == Vector3.zero)
            {
                _direction = new Vector3(_random.Next(-4, 4), _random.Next(-4, 4), 0f).normalized;
            }
        }
    }
}