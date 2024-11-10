using System;
using UnityEngine;

namespace Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _lifeTime = 3f;

        private void FixedUpdate()
        {
            Move();
        }

        private void Awake()
        {
            Destroy(gameObject, _lifeTime);
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Asteroid") || other.gameObject.CompareTag("FragmentAsteroid"))
            {
                Debug.Log("collision");
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }

        private void Move()
        {
            transform.Translate(Vector3.up * _speed * Time.fixedDeltaTime);
        }
    }
}