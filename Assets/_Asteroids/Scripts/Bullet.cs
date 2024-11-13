using System;
using UnityEngine;

namespace Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] protected float _speed = 5f;
        [SerializeField] protected float _lifeTime = 3f;

        private protected virtual void Awake()
        {
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

        private void Move()
        {
            transform.Translate(Vector3.up * _speed * Time.fixedDeltaTime);
        }
    }
}