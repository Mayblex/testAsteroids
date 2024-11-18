using System;
using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ship : MonoBehaviour, IInputHandler, IDamageable
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Laser _laser;

        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _rotationSpeed = 5f;

        private Rigidbody _rigidbody;

        private Vector2 _moveDirection;
        private float _rotationZ;

        public void Constract(Laser laser)
        {
            _laser = laser;
        }
        
        public event Action Died;

        public void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            MoveInternal();
        }

        private void OnCollisionEnter(Collision other)
        {
            TakeDamage();
        }

        public void MoveForward(float input)
        {
            _moveDirection = transform.up * input;
        }

        public void Turn(float rotationZ)
        {
            _rotationZ = rotationZ;
        }

        private void MoveInternal()
        {
            _rigidbody.linearVelocity = _moveDirection * _moveSpeed;
            var deltaRotation = Quaternion.Euler(0f, 0f, 1f * _rotationSpeed);
            _rigidbody.MoveRotation(_rigidbody.rotation *
                                    Quaternion.Euler(0f, 0f, _rotationZ * _rotationSpeed * Time.fixedDeltaTime));
        }

        public void DefaultAtack()
        {
            Instantiate(_bulletPrefab, transform.position, transform.rotation);
        }

        public void SpecialAtack()
        {
            _laser.Shoot();
        }

        public void TakeDamage()
        {
            Died?.Invoke();
            gameObject.SetActive(false);
        }
    }
}