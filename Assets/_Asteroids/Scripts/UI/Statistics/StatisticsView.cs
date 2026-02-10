using TMPro;
using UnityEngine;
using Zenject;

namespace _Asteroids.Scripts.UI.Statistics
{
    public class StatisticsView : MonoBehaviour
    {
        private const string TEXT_POSITION = "X, Y: ";
        private const string TEXT_SPEED = "Speed: ";
        private const string TEXT_ROTATION = "Rotation: ";
        private const string TEXT_NUMBER_LASER = "Laser: ";
        private const string TEXT_TIME_RECHARGE = "Time: ";

        [SerializeField] private TextMeshProUGUI _position;
        [SerializeField] private TextMeshProUGUI _speed;
        [SerializeField] private TextMeshProUGUI _rotation;
        [SerializeField] private TextMeshProUGUI _numberLaser;
        [SerializeField] private TextMeshProUGUI _timeRecharge;

        public void SetPosition(string position) => 
            _position.text = TEXT_POSITION + position;

        public void SetSpeed(string speed) => 
            _speed.text = TEXT_SPEED + speed;

        public void SetRotation(string rotation) => 
            _rotation.text = TEXT_ROTATION + rotation;

        public void SetNumberLaser(string numberLaser) => 
            _numberLaser.text = TEXT_NUMBER_LASER + numberLaser;

        public void SetTimeRecharge(string timeRecharge) => 
            _timeRecharge.text = TEXT_TIME_RECHARGE + timeRecharge;
    }
}