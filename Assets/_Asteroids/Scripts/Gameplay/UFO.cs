using System;
using _Asteroids.Scripts.Configs;
using _Asteroids.Scripts.Core;
using _Asteroids.Scripts.Services;
using UnityEngine;
using Zenject;
using IPoolable = _Asteroids.Scripts.Core.Pool.IPoolable;

namespace _Asteroids.Scripts.Gameplay
{
    public class UFO : MonoBehaviour, IDamageable, IPoolable
    {
        private const string UFO_CONFIG = "ufoConfig";
        
        [SerializeField] private float _speed = 5f;
        
        private Transform _target;
        private Rigidbody _rigidbody;
        private UFOConfig _config;
        private IRemoteConfigService _configService;

        [Inject]
        public void Construct(IRemoteConfigService configService)
        {
            _configService = configService;
        }

        public event Action<GameObject> Released;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _config = _configService.GetValue<UFOConfig>(UFO_CONFIG);
            _speed = _config.Speed;
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