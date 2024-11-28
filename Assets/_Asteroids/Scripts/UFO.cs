using UnityEngine;

namespace Scripts
{
    public class UFO : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _speed = 5f;
        
        private Transform _target;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _target = GameObject.FindWithTag(nameof(Ship)).transform;
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void SetTarget(Transform target) => 
            _target = target;

        public void TakeDamage() => 
            Destroy(gameObject);

        private void Move()
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            _rigidbody.linearVelocity =  _speed * direction;
        }
    }
}