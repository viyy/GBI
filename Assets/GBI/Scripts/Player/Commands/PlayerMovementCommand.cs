namespace Geekbrains
{
    public class PlayerMovementCommand : InputCommand
    {
        private float _horizontalAxis;
        private float _verticalAxis;

        public void SetHorizontalAndVerticalAxis(float horizontalAxis, float verticalAxis)
        {
            _horizontalAxis = horizontalAxis;
            _verticalAxis = verticalAxis;
        }

        protected override void InternalExecute()
        {
            Main.Instance.PlayerController.HorizontalAxis = _horizontalAxis;
            Main.Instance.PlayerController.VerticalAxis = _verticalAxis;
        }

        protected override void InternalInitialize()
        {
            _isEnabledInPause = false;
            _commandType = GetType();
        }
    } 
}
