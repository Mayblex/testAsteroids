using TMPro;
using UnityEngine;

namespace Scripts
{
    public class UIGameplay : MonoBehaviour
    {
        const string TextSpeed = "Speed: ";
        const string TextRotation = "Rotation: ";
        const string TextNumberLaser = "Laser: ";
        
        [SerializeField] private TextMeshProUGUI _canvasTextSpeed;
        [SerializeField] private TextMeshProUGUI _canvasTextRotation;
        [SerializeField] private TextMeshProUGUI _canvasTextNumberLaser;
        [SerializeField] private Ship _ship;
        
        private Rigidbody _shipRigidbody;

        private void Start()
        {
            Ship.ChangeNumberLaser += OnChangeNumberLaser;
            
            _shipRigidbody = GameObject.FindWithTag("Ship").GetComponent<Rigidbody>();

            _canvasTextNumberLaser.text = TextNumberLaser + _ship.NumberLaser;
        }

        private void Update()
        {
            _canvasTextSpeed.text = TextSpeed + _shipRigidbody.linearVelocity.magnitude;
            _canvasTextRotation.text = TextRotation + _shipRigidbody.angularVelocity.magnitude;
        }

        private void OnChangeNumberLaser()
        {
            _canvasTextNumberLaser.text = TextNumberLaser + _ship.NumberLaser;
        }
    }
}