using System;
using System.Collections;
using UnityEngine;

namespace _Asteroids.Scripts.Core
{
    public class CoroutineRunner : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public Coroutine StartRoutine(IEnumerator routine) => 
            StartCoroutine(routine);
        
        public void StopRoutine(Coroutine routine) => 
            StopCoroutine(routine);
    }
}