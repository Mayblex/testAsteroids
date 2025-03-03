using System;
using System.Collections;
using _Asteroids.Scripts.Configs;
using _Asteroids.Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.Gameplay.Ship
{
    public class Laser : MonoBehaviour
    {
        private const string LASER_CONFIG = "laserConfig";
        
        [SerializeField] private GameObject _view;
        [SerializeField] private float _lifeTime = 0.6f;
        [SerializeField] private int _maxNumber = 3;
        
        private bool _canCharge = true;
        private LaserConfig _config;

        [Inject]
        public void Construct(IRemoteConfigService configService)
        {
            _config = configService.GetValue<LaserConfig>(LASER_CONFIG);
        }
        
        public event Action NumberChanged;
        public event Action RechargeStarted;
        
        [field: SerializeField] public int Number { get; private set; } = 3;
        [field: SerializeField] public float TimeRecharge { get; private set; } = 5f;
        
        public void Initialize()
        {
            _lifeTime = _config.LifeTime;
            _maxNumber = _config.MaxNumber;
            TimeRecharge = _config.TimeRecharge;
            NumberChanged?.Invoke();
        }
        
        public void Shoot()
        {
            if (Number > 0)
            {
                Number -= 1;

                NumberChanged?.Invoke();

                _view.SetActive(true);

                StartCoroutine(SwitchOffLaser());

                if (_canCharge)
                {
                    _canCharge = false;
                    StartCoroutine(RechargeLaser());
                }
            }
        }

        private IEnumerator RechargeLaser()
        {
            if (Number != _maxNumber)
            {
                RechargeStarted?.Invoke();
                
                yield return new WaitForSeconds(TimeRecharge);
                
                Number += 1;
                
                NumberChanged?.Invoke();
                StartCoroutine(RechargeLaser());
            }
            else
            {
                _canCharge = true;
            }
        }
        
        private IEnumerator SwitchOffLaser()
        {
            yield return new WaitForSeconds(_lifeTime);

            _view.SetActive(false);
        }
    }
}