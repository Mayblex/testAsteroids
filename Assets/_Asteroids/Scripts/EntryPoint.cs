using UnityEngine;

namespace Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private InputController _inputController;
        [SerializeField] private UIStatistics _uiStatistics;
        [SerializeField] private Ship _ship;
        [SerializeField] private Laser _laser;
        [SerializeField] private Spawner _spawner;
        [SerializeField] private GameObject _asteroidPrefab;
        [SerializeField] private GameObject _ufoPrefab;
        
        private AsteroidFactory _asteroidFactory;
        private UFOFactory _ufoFactory;
        //private ShipFactory _shipFactory;
        //private GameObject _shipPrefab;

        private void Awake()
        {
            _asteroidFactory = new AsteroidFactory(_asteroidPrefab);
            _ufoFactory = new UFOFactory(_ufoPrefab);
            //_shipFactory = new ShipFactory();
            //_shipPrefab = _shipFactory.Create(Vector2.zero);
            _laser.Initialize();
            _ship.Initialize();
            //_inputController.Initialize();
        }

        private void Start()
        {
            _ship.Constract(_laser);
            _uiStatistics.Constract(_ship, _laser);
            _uiStatistics.Run();
            _spawner.Constract(_asteroidFactory, _ufoFactory);
            _spawner.Run();
        }
    }
}