using System;
using System.Collections;
using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ship : MonoBehaviour, IInputHandler, IDamageable
    {
        public static event Action NumberLaserChanged;
        public static event Action RechargeStarted;

        public int NumberLaser => _numberLaser;
        public float TimeRechargeLaser => _timeRechargeLaser;

        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private GameObject _laser;

        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _rotationSpeed = 5f;
        [SerializeField] private float _lifeTimeLaser = 0.6f;
        [SerializeField] private float _timeRechargeLaser = 5f;
        [SerializeField] private int _numberLaser = 3;
        [SerializeField] private int _maxNumberLaser = 3;

        private Rigidbody _rigidbody;

        private Vector2 _moveDirection;
        private float _rotationZ;
        private bool _canCharge = true;

        private void Awake()
        {
            NumberLaserChanged?.Invoke();

            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            MoveInternal();
        }

        private void OnCollisionEnter(Collision other)
        {
            TakeDamage();
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
            _rigidbody.MoveRotation(_rigidbody.rotation *
                                    Quaternion.Euler(0f, 0f, _rotationZ * _rotationSpeed * Time.fixedDeltaTime));
        }

        public void DefaultAtack()
        {
            Instantiate(_bulletPrefab, transform.position, transform.rotation);
        }

        public void SpecialAtack()
        {
            if (_numberLaser > 0)
            {
                _numberLaser -= 1;

                NumberLaserChanged?.Invoke();

                _laser.SetActive(true);

                StartCoroutine(SwitchOffLaser());

                if (_canCharge)
                {
                    _canCharge = false;
                    StartCoroutine(RechargeLaser());
                }
            }
        }

        public void TakeDamage()
        {
            gameObject.SetActive(false);
        }

        private IEnumerator SwitchOffLaser()
        {
            yield return new WaitForSeconds(_lifeTimeLaser);

            _laser.SetActive(false);
        }

        private IEnumerator RechargeLaser()
        {
            if (_numberLaser != _maxNumberLaser)
            {
                RechargeStarted?.Invoke();
                
                yield return new WaitForSeconds(_timeRechargeLaser);
                
                _numberLaser += 1;
                
                NumberLaserChanged?.Invoke();
                StartCoroutine(RechargeLaser());
            }
            else
            {
                _canCharge = true;
            }
        }
    }
}