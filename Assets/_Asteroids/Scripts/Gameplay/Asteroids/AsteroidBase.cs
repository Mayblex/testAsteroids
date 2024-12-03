using System;
using _Asteroids.Scripts.Core;
using _Asteroids.Scripts.Core.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Asteroids.Scripts.Gameplay.Asteroids
{
    public abstract class AsteroidBase : MonoBehaviour, IDamageable, IPoolable
    {
        [SerializeField] private float _speed = 5f;

        private Vector2 _direction;
        private Rigidbody _rigidbody;

        public event Action<GameObject> Released;

        private void Awake()
        {
            SetRandomDirection();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private protected virtual void OnDestroy()
        {
            Released = null;
        }

        public void TakeDamage()
        {
            PerformOnDie();
            Released?.Invoke(gameObject);
        }

        private protected virtual void PerformOnDie() { }

        private void Move() => 
            _rigidbody.linearVelocity = _speed * _direction;

        private void SetRandomDirection()
        {
            _direction = Random.insideUnitCircle.normalized;
        }
    }
}