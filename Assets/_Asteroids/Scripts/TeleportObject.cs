using UnityEngine;

namespace Scripts
{
    public class TeleportObject : MonoBehaviour
    {
        [field: SerializeField] public float AdditionDistance { get; private set; } = 1f;
    }
}