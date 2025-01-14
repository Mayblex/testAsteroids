using _Asteroids.Scripts.Configs;
using _Asteroids.Scripts.Core;
using _Asteroids.Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Gameplay.Ship
{
    public class Bullet : MonoBehaviour
    {
        private const string BULLET_CONFIG = "bullet_config";
        
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _lifeTime = 3f;
        
        private Rigidbody _rigidbody;
        private BulletConfig _config;
        private IRemoteConfigService _configService;

        [Inject]
        public void Construct(IRemoteConfigService configService)
        {
            _configService = configService;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _config = _configService.GetValue<BulletConfig>(BULLET_CONFIG);
            _speed = _config.Speed;
            _lifeTime = _config.LifeTime;
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