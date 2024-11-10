using UnityEngine;

namespace Scripts
{
    public interface IInput
    {
        void MoveForward(float directionForward);
        void Turn(float rotationZ);
        void DefaultAtack();
        void SpecialAtack();
    }
}