using System;
using _Asteroids.Scripts.Core;
using _Asteroids.Scripts.Core.Pool;
using UnityEngine;

namespace _Asteroids.Scripts.Gameplay
{
    public class UFO : MonoBehaviour, IDamageable, IPoolable
    {
        [SerializeField] private float _speed = 5f;
        
        private Transform _target;
        private Rigidbody _rigidbody;

        public event Action<GameObject> Released;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void SetTarget(Transform target) => 
            _target = target;

        public void TakeDamage() => 
            Released?.Invoke(gameObject);

        private void Move()
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            _rigidbody.linearVelocity =  _speed * direction;
        }
    }
}