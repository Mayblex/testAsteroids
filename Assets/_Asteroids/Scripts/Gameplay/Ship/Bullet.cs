using _Asteroids.Scripts.Core;
using UnityEngine;

namespace _Asteroids.Scripts.Gameplay.Ship
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _lifeTime = 3f;
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            Destroy(gameObject, _lifeTime);
        }

        private void FixedUpdate()
        {
            Move();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IDamageable>(out IDamageable recipient))
            {
                recipient.TakeDamage();
                Destroy(gameObject);
            }
        }

        private void Move() => 
            _rigidbody.linearVelocity = transform.up * _speed;
    }
}