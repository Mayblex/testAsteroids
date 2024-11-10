using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class Ship : MonoBehaviour, IInput
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _target;
        
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _rotationSpeed = 5f;

        private Rigidbody _rigidbody;
        private CharacterController _controller;

        private Vector2 _moveDirection;
        private float _rotationZ;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _controller = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            MoveInternal();
        }

        public void MoveForward(float directionForward)
        {
            var direction = new Vector2(_target.position.x - transform.position.x, _target.position.y - transform.position.y);
            _moveDirection = direction.normalized * directionForward;
        }

        public void Turn(float rotationZ)
        {
            _rotationZ = rotationZ;
        }

        public void DefaultAtack()
        {
            Instantiate(_bulletPrefab, _target.position, transform.rotation);
        }

        public void SpecialAtack()
        {
            
        }

        private void MoveInternal()
        {
            //_rigidbody.AddForce(_moveDirection * _moveSpeed, ForceMode.Impulse);
            _controller.Move(_moveDirection * _moveSpeed * Time.fixedDeltaTime);
            _controller.transform.Rotate(0f, 0f, _rotationZ * _rotationSpeed * Time.fixedDeltaTime);
        }
    }
}