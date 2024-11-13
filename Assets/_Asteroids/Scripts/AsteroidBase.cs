﻿using UnityEngine;

namespace Scripts
{
    public abstract class AsteroidBase : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _speed = 5f;
        
        private Vector3 _direction = Vector3.zero;

        private void Awake()
        {
            SetRandomDirection();
        }

        private void FixedUpdate()
        {
            transform.Translate(_direction * _speed * Time.fixedDeltaTime);
        }

        public void TakeDamage()
        {
            Destroy(gameObject);
        }

        private void SetRandomDirection()
        {
            while(_direction == Vector3.zero)
            {
                _direction = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0f).normalized;
            }
        }
    }
}