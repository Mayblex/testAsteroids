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
        private const float ValidToY = 16f;
        private const float ValidToX = 33f;
        private const float InvalidToX = 26f;
        private const float InvalidToY = 12f;

        [SerializeField] private int _numberAsteroid;
        [SerializeField] private int _numberUFO;

        private ObjectPool _asteroidPool;
        private ObjectPool _fragmentAsteroidPool;
        private ObjectPool _ufoPool;
        private float _time = 25f;
        private float _deltaTime = 7f;

        public void Constract(AsteroidFactory asteroidFactory, AsteroidFactory fragmentAsteroidFactory,
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

        private void OnCreating(GameObject parent,Vector3 position)
        {
            var asteroid = _fragmentAsteroidPool.Get();
            asteroid.transform.position = position;
            parent.GetComponent<Asteroid>().Creating -= OnCreating;
        }

        private Vector3 GeneratePosition()
        {
            Vector3 position = Vector3.zero;

            while (position.x < InvalidToX && position.y < InvalidToY)
            {
                position.y = Random.Range(-ValidToY, ValidToY);
                position.x = Random.Range(-ValidToX, ValidToX);
            }

            return position;
        }
    }
}