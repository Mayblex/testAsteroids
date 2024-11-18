using UnityEngine;

namespace Scripts
{
    public abstract class AsteroidBase : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _speed = 5f;

        private Vector2 _direction;

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
            PerformOnDie();
            Destroy(gameObject);
        }

        private protected virtual void PerformOnDie() { }

        private void SetRandomDirection()
        {
            _direction = Random.insideUnitCircle.normalized;
        }
    }
}