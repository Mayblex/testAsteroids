using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ship : MonoBehaviour, IInputHandler
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private GameObject _laser;
        
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _rotationSpeed = 5f;
        [SerializeField] private float _lifeTimeLaser = 0.6f;

        private Rigidbody _rigidbody;

        private Vector2 _moveDirection;
        private float _rotationZ;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            MoveInternal();
        }

        public void MoveForward(float input)
        {
            _moveDirection = transform.up * input;
        }

        public void Turn(float rotationZ)
        {
            _rotationZ = rotationZ;
        }

        private void MoveInternal()
        {
            _rigidbody.linearVelocity = _moveDirection * _moveSpeed;
            var deltaRotation = Quaternion.Euler(0f, 0f, 1f * _rotationSpeed);
            _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0f, 0f, _rotationZ * _rotationSpeed * Time.fixedDeltaTime));
        }

        public void DefaultAtack()
        {
            Instantiate(_bulletPrefab, transform.position, transform.rotation);
        }

        public void SpecialAtack()
        {
            _laser.SetActive(true);

            Invoke(nameof(SwitchOff), _lifeTimeLaser);
        }

        private void SwitchOff()
        {
            _laser.SetActive(false);
        }
    }
}