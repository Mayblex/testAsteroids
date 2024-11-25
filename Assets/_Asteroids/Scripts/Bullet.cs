using UnityEngine;

namespace Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] protected float _speed = 5f;
        [SerializeField] protected float _lifeTime = 3f;
        
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