using System;
using System.Collections;
using UnityEngine;

namespace Scripts
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] private GameObject _view;
        [SerializeField] private float _lifeTime = 0.6f;
        [SerializeField] private int _maxNumber = 3;
        
        private bool _canCharge = true;
        
        public event Action NumberChanged;
        public event Action RechargeStarted;
        
        [field: SerializeField] public int Number { get; private set; } = 3;
        [field: SerializeField] public float TimeRecharge { get; private set; } = 5f;
        
        public void Initialize()
        {
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