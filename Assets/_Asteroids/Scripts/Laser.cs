﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts
{
    public class Laser : MonoBehaviour
    {
        public event Action NumberChanged;
        public event Action RechargeStarted;
        
        public int Number => _number;
        public float TimeRecharge => _timeRecharge;

        [SerializeField] private GameObject _view;
        [SerializeField] private float _lifeTime = 0.6f;
        [SerializeField] private float _timeRecharge = 5f;
        [SerializeField] private int _number = 3;
        [SerializeField] private int _maxNumber = 3;
        
        private bool _canCharge = true;

        private void Awake()
        {
            NumberChanged?.Invoke();
        }

        public void Shoot()
        {
            if (_number > 0)
            {
                _number -= 1;

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
            if (_number != _maxNumber)
            {
                RechargeStarted?.Invoke();
                
                yield return new WaitForSeconds(_timeRecharge);
                
                _number += 1;
                
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