using System;
using _Asteroids.Scripts.Core;
using _Asteroids.Scripts.Services;
using UnityEngine;
using Zenject;
using IPoolable = _Asteroids.Scripts.Core.Pool.IPoolable;
using Random = UnityEngine.Random;

namespace _Asteroids.Scripts.Gameplay.Asteroids
{
    public abstract class AsteroidBase : MonoBehaviour, IDamageable, IPoolable
    {
        [SerializeField] private protected float _speed = 5f;

        private Vector2 _direction;
        private Rigidbody _rigidbody;
        private protected IRemoteConfigService _configService;

        [Inject]
        public void Construct(IRemoteConfigService configService)
        {
            _configService = configService;
        }

        public event Action<GameObject> Released;

        private void Awake()
        {
            SetRandomDirection();
            _rigidbody = GetComponent<Rigidbody>();
            ApplyConfig();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void TakeDamage()
        {
            PerformOnDie();
            Released?.Invoke(gameObject);
        }

        private protected virtual void ApplyConfig() { }
        
        private protected virtual void PerformOnDie() { }
        
        private void Move() => 
            _rigidbody.linearVelocity = _speed * _direction;

        private void SetRandomDirection()
        {
            _direction = Random.insideUnitCircle.normalized;
        }
    }
}