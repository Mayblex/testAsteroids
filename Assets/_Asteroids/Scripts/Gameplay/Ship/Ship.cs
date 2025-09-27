using System;
using _Asteroids.Scripts.Configs;
using _Asteroids.Scripts.Core;
using _Asteroids.Scripts.Core.Input;
using _Asteroids.Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Gameplay.Ship
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ship : MonoBehaviour, IInputHandler, IShip, IDamageable
    {
        private const string SHIP_CONFIG = "shipConfig";
        
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _rotationSpeed = 5f;
        [SerializeField] private Laser _laser;

        private IAdsService _adsService;
        private Rigidbody _rigidbody;
        private Vector2 _moveDirection;
        private float _rotationZ;
        private ShipConfig _config;
        
        [Inject]
        public void Construct(IRemoteConfigService configService, IAdsService adsService)
        {
            _config = configService.GetValue<ShipConfig>(SHIP_CONFIG);
            _adsService = adsService;
        }
        
        public event Action Died;
        public event Action BulletShot;
        public event Action LaserShot;
        
        public Vector2 Position { get; private set; }
        public float Speed { get; private set; }
        public double Rotation { get; private set; }
        
        public void Initialize()
        {
            _adsService.OnRewardedAdCompleted += Respawn;
            
            _rigidbody = GetComponent<Rigidbody>();
            _moveSpeed = _config.MoveSpeed;
            _rotationSpeed = _config.RotationSpeed;
        }
        
        private void Update()
        {
            Position = transform.position;
            Speed = _rigidbody.linearVelocity.magnitude;
            Rotation = Math.Round(_rigidbody.angularVelocity.magnitude, 2);
        }
        
        private void FixedUpdate()
        {
            Move();
        }
        
        private void OnCollisionEnter(Collision other) => 
            TakeDamage();
        
        public void MoveForward(float input) => 
            _moveDirection = transform.up * input;
        
        public void Turn(float rotationZ) => 
            _rotationZ = rotationZ;

        public void DefaultAtack()
        {
            Instantiate(_bulletPrefab, transform.position, transform.rotation);
            BulletShot?.Invoke();
        }

        public void SpecialAtack()
        {
            _laser.Shoot();
            LaserShot?.Invoke();
        }

        public void TakeDamage()
        {
            Died?.Invoke();
            gameObject.SetActive(false);
        }

        private void Move()
        {
            _rigidbody.linearVelocity = _moveDirection * _moveSpeed;
            _rigidbody.angularVelocity = Vector3.forward * (_rotationZ * _rotationSpeed);
        }

        private void Respawn()
        {
            gameObject.SetActive(true);
        }
    }
}