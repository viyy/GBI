namespace Geekbrains
{
    public class MouseLookCommand : InputCommand
    {
        private float _mouseXAxis;
        private float _mouseYAxis;

        public void SetHorizontalAndVerticalAxis(float mouseXAxis, float mouseYAxis)
        {
            _mouseXAxis = mouseXAxis;
            _mouseYAxis = mouseYAxis;
        }

        protected override void InternalExecute()
        {
            Main.Instance.PlayerController.MouseXAxis = _mouseXAxis;
            Main.Instance.PlayerController.MouseYAxis = _mouseYAxis;
        }

        protected override void InternalInitialize()
        {
            _isEnabledInPause = false;
            _commandType = GetType();
        }        
    }
}
