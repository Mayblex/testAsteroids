﻿using _Asteroids.Scripts.Core.Factory;
using _Asteroids.Scripts.Core.Input;
using _Asteroids.Scripts.Gameplay.Ship;
using _Asteroids.Scripts.Gameplay.Spawn;
using _Asteroids.Scripts.UI;
using UnityEngine;

namespace _Asteroids.Scripts.Core
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private UIStatistics _uiStatistics;
        [SerializeField] private Spawner _spawner;
        [SerializeField] private GameObject _asteroidPrefab;
        [SerializeField] private GameObject _fragmentasteroidPrefab;
        [SerializeField] private GameObject _ufoPrefab;
        [SerializeField] private GameObject _shipPrefab;

        private PlayerInput _playerInput;
        private IInputHandler _inputHandler;
        private InputController _inputController;
        private CommonFactory _shipFactory;
        private AsteroidFactory _asteroidFactory;
        private AsteroidFactory _fragmentAsteroidFactory;
        private UFOFactory _ufoFactory;
        private Ship _ship;
        private Laser _laser;
        private GameObject _player;

        private void Awake()
        {
            _shipFactory = new CommonFactory(_shipPrefab);
            _player = _shipFactory.Create(Vector2.zero);
            _ship = _player.GetComponent<Ship>();
            _ship.Initialize();
            _laser = _player.GetComponentInChildren<Laser>();
            _laser.Initialize();
            _asteroidFactory = new AsteroidFactory(_asteroidPrefab, 15);
            _fragmentAsteroidFactory = new AsteroidFactory(_fragmentasteroidPrefab, 22);
            _ufoFactory = new UFOFactory(_ufoPrefab, 7, _ship.transform);
            _playerInput = new PlayerInput();
            _inputHandler = _player.GetComponent<IInputHandler>();
            _inputController = new InputController(_playerInput, _inputHandler);
        }

        private void Start()
        {
            _ship.Construct(_laser);
            _uiStatistics.Construct(_ship, _laser);
            _uiStatistics.Run();
            _spawner.Construct(_asteroidFactory, _fragmentAsteroidFactory, _ufoFactory);
            _spawner.Run();
        }

        private void Update()
        {
            _inputController.ProcessInput();
        }

        private void OnDestroy()
        {
            _inputController.Dispose();
        }
    }
}