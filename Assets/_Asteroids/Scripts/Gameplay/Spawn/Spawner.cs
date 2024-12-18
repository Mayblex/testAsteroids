using System.Collections;
using _Asteroids.Scripts.Core;
using _Asteroids.Scripts.Core.Factory;
using _Asteroids.Scripts.Core.Pool;
using _Asteroids.Scripts.Gameplay.Asteroids;
using _Asteroids.Scripts.Installers;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Asteroids.Scripts.Gameplay.Spawn
{
    public class Spawner
    {
        private const float VALID_TO_Y = 16f;
        private const float VALID_TO_X = 33f;
        private const float INVALID_TO_X = 26f;
        private const float INVALID_TO_Y = 12f;
        
        private readonly CustomObjectPool<AsteroidBase> _asteroidPool;
        private readonly CustomObjectPool<AsteroidBase> _fragmentAsteroidPool;
        private readonly CustomObjectPool<UFO> _ufoPool;
        private readonly CoroutineRunner _coroutineRunner;
        private int _numberAsteroid = 3;
        private int _numberUFO = 1;
        private float _time = 25f;
        private float _deltaTime = 7f;
        
        public Spawner([Inject(Id = InstallerIds.ASTEROID_FACTORY)] AsteroidFactory asteroidFactory,
            [Inject(Id = InstallerIds.FRAGMENT_ASTEROID_FACTORY)]
            AsteroidFactory fragmentAsteroidFactory,
            UFOFactory ufoFactory, CoroutineRunner coroutineRunner)
        {
            _ufoPool = ufoFactory.GetPool();
            _asteroidPool = asteroidFactory.GetPool();
            _fragmentAsteroidPool = fragmentAsteroidFactory.GetPool();
            _coroutineRunner = coroutineRunner;
        }
        
        public void Run()
        {
            Spawn(_numberAsteroid, _numberUFO);
            _coroutineRunner.StartRoutine(SpawnObjectsAfterTime());
        }
        
        private IEnumerator SpawnObjectsAfterTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(_time);

                Spawn(_numberAsteroid, _numberUFO);

                _time += _deltaTime;
                _numberAsteroid += 2;
                _numberUFO += 1;
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