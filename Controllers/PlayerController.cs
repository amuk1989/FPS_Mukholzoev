namespace FPSAmuk
{
    public sealed class PlayerController : BaseControllers, IExecute
    {
        private readonly IMotor _motor;

        public PlayerController(IMotor motor)
        {
            _motor = motor;
        }

        public void Execute()
        {
            if (!IsActive) return;
            _motor.Move();
        }
    }
}
