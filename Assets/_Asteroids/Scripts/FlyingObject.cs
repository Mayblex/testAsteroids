using UnityEngine;

namespace Scripts
{
    public class FlyingObject : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _speedFollow = 5f;
        
        private Transform _target;

        private void Awake()
        {
            _target = GameObject.FindWithTag(nameof(Ship)).transform;
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speedFollow * Time.deltaTime);
        }
        
        public void TakeDamage()
        {
            Destroy(gameObject);
        }
    }
}