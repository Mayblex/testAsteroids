using System.Collections;
using _Asteroids.Scripts.Core.Factory;
using _Asteroids.Scripts.Core.Pool;
using _Asteroids.Scripts.Gameplay.Asteroids;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Asteroids.Scripts.Gameplay.Spawn
{
    public class Spawner : MonoBehaviour
    {
        private const float VALID_TO_Y = 16f;
        private const float VALID_TO_X = 33f;
        private const float INVALID_TO_X = 26f;
        private const float INVALID_TO_Y = 12f;
        
        [SerializeField] private int _numberAsteroid;
        [SerializeField] private int _numberUFO;
        
        private ObjectPool _asteroidPool;
        private ObjectPool _fragmentAsteroidPool;
        private ObjectPool _ufoPool;
        private float _time = 25f;
        private float _deltaTime = 7f;
        
        public void Construct(AsteroidFactory asteroidFactory, AsteroidFactory fragmentAsteroidFactory,
            UFOFactory ufoFactory)
        {
            _ufoPool = ufoFactory.GetPool();
            _asteroidPool = asteroidFactory.GetPool();
            _fragmentAsteroidPool = fragmentAsteroidFactory.GetPool();
        }
        
        public void Run()
        {
            Spawn(_numberAsteroid, _numberUFO);
            StartCoroutine(SpawnObjectsAfterTime());
        }
        
        private IEnumerator SpawnObjectsAfterTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(_time);

                Spawn(_numberAsteroid, _numberUFO);

                _time += _deltaTime;
                _numberAsteroid += _numberAsteroid;
                _numberUFO += _numberUFO;
            }
        }
        
        private void Spawn(int numberAsteroid, int numberUFO)
        {
            for (int i = 0; i < numberAsteroid; i++)
            {
                var asteroid = _asteroidPool.Get();
                asteroid.transform.position = GeneratePosition();
                asteroid.GetComponent<Asteroid>().Creating += OnCreating;
            }
            
            for (int i = 0; i < numberUFO; i++)
            {
                var ufo = _ufoPool.Get();
                ufo.transform.position = GeneratePosition();
            }
        }
        
        private void OnCreating(GameObject parent, int number, Vector3 position)
        {
            for (int i = 0; i < number; i++)
            { 
                var asteroid = _fragmentAsteroidPool.Get(); 
                asteroid.transform.position = position;
            }
            
            parent.GetComponent<Asteroid>().Creating -= OnCreating;
        }
        
        private Vector3 GeneratePosition()
        {
            Vector3 position = Vector3.zero;
            
            while (position.x < INVALID_TO_X && position.y < INVALID_TO_Y)
            {
                position.y = Random.Range(-VALID_TO_Y, VALID_TO_Y);
                position.x = Random.Range(-VALID_TO_X, VALID_TO_X);
            }
            
            return position;
        }
    }
}