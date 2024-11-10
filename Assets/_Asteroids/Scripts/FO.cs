using UnityEngine;

namespace Scripts
{
    public class FO : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _shootDelay = 3f;
        
        [SerializeField] private GameObject _bulletPrefab;
        private Vector2 _shootDirection;

        private void Update()
        {
            Invoke(nameof(DefaultAtack), _shootDelay);
        }

        public void TakeDamage()
        {
            Destroy(gameObject);
        }

        public void DefaultAtack()
        {
            Instantiate(_bulletPrefab, transform.position, transform.rotation);
        }
    }
}