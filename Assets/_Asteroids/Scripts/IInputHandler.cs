namespace Scripts
{
    public interface IInputHandler
    {
        void MoveForward(float directionForward);
        void Turn(float rotationZ);
        void DefaultAtack();
        void SpecialAtack();
    }
}