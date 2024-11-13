using TMPro;
using UnityEngine;

namespace Scripts
{
    public class UIGameplay : MonoBehaviour
    {
        const string TextSpeed = "Speed: ";
        const string TextRotation = "Rotation: ";
        const string TextNumberLaser = "Laser: ";
        const string TextTimeRecharge = "Time: ";

        [SerializeField] private TextMeshProUGUI _canvasTextPosition;
        [SerializeField] private TextMeshProUGUI _canvasTextSpeed;
        [SerializeField] private TextMeshProUGUI _canvasTextRotation;
        [SerializeField] private TextMeshProUGUI _canvasTextNumberLaser;
        [SerializeField] private TextMeshProUGUI _canvasTextTimeRecharge;
        [SerializeField] private Ship _ship;

        private Rigidbody _shipRigidbody;
        private float _currentTime;

        private void Start()
        {
            Ship.NumberLaserChanged += OnNumberLaserChanged;
            Ship.RechargeStarted += OnRechargeStarted;

            _shipRigidbody = GameObject.FindWithTag("Ship").GetComponent<Rigidbody>();

            _canvasTextNumberLaser.text = TextNumberLaser + _ship.NumberLaser;
            _canvasTextTimeRecharge.text = TextTimeRecharge + 0;
        }

        private void Update()
        {
            _canvasTextPosition.text = _shipRigidbody.position.ToString("F1");
            _canvasTextSpeed.text = TextSpeed + _shipRigidbody.linearVelocity.magnitude;
            //_canvasTextRotation.text = TextRotation + _shipRigidbody.angularVelocity.magnitude;
            _canvasTextRotation.text = TextRotation + Mathf.Round(_shipRigidbody.transform.eulerAngles.z);

            ChangeTime();
        }

        private void OnNumberLaserChanged()
        {
            _canvasTextNumberLaser.text = TextNumberLaser + _ship.NumberLaser;
        }

        private void OnRechargeStarted()
        {
            _currentTime = _ship.TimeRechargeLaser;
        }

        private void ChangeTime()
        {
            if (_currentTime > 0)
            {
                _currentTime -= Time.deltaTime;

                _canvasTextTimeRecharge.text = string.Format($"{_currentTime:F}");
            }
        }
    }
}