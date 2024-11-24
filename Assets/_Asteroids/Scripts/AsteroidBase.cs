using UnityEngine;

namespace Scripts
{
    public abstract class AsteroidBase : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _speed = 5f;

        private Vector2 _direction;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            SetRandomDirection();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void TakeDamage()
        {
            PerformOnDie();
            Destroy(gameObject);
        }

        private protected virtual void PerformOnDie() { }

        private void Move() => 
            _rigidbody.linearVelocity = _speed * _direction;

        private void SetRandomDirection()
        {
            _direction = Random.insideUnitCircle.normalized;
        }
    }
}