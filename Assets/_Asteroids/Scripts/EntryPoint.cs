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

        private void Awake()
        {
            _inputController.Initialize();
            _laser.Initialize();
            _ship.Initialize();
        }

        private void Start()
        {
            _ship.Constract(_laser);
            _uiStatistics.Constract(_ship, _laser);
            _uiStatistics.Run();
            _spawner.Run();
        }
    }
}