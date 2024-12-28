using System;
using _Asteroids.Scripts.Core;
using _Asteroids.Scripts.Core.Input;
using UnityEngine;

namespace _Asteroids.Scripts.Gameplay.Ship
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ship : MonoBehaviour, IInputHandler, IReadonlyShip, IDamageable
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _rotationSpeed = 5f;
        [SerializeField] private Laser _laser; 
        
        private Rigidbody _rigidbody;
        private Vector2 _moveDirection;
        private float _rotationZ;
        
        public event Action Died;
        public event Action BulletShot;
        public event Action LaserShot;
        
        public Vector2 Position { get; private set; }
        public float Speed { get; private set; }
        public double Rotation { get; private set; }
        
        public void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void Update()
        {
            Position = transform.position;
            Speed = _rigidbody.linearVelocity.magnitude;
            Rotation = Math.Round(_rigidbody.angularVelocity.magnitude, 2);
        }
        
        private void FixedUpdate()
        {
            MoveInternal();
        }
        
        private void OnCollisionEnter(Collision other) => 
            TakeDamage();
        
        public void MoveForward(float input) => 
            _moveDirection = transform.up * input;
        
        public void Turn(float rotationZ) => 
            _rotationZ = rotationZ;
        
        private void MoveInternal()
        {
            _rigidbody.linearVelocity = _moveDirection * _moveSpeed;
            _rigidbody.angularVelocity = Vector3.forward * (_rotationZ * _rotationSpeed);
        }
        
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
    }
}