namespace  Geekbrains
{
    public class PlayerEventArgs : BaseEvent
    {        
        public float HorizontalAxis { get; private set; }
        public float VerticalAxis { get; private set; }
        public float MouseXAxis { get; private set; }
        public float MouseYAxis { get; private set; }
        public float FixedTime { get; set; }

        public PlayerEventArgs(float horizontalAxis, float verticalAxis, float mouseXAxis, float mouseYAxis, float fixedTime)
        {
            HorizontalAxis = horizontalAxis;
            VerticalAxis = verticalAxis;
            MouseXAxis = mouseXAxis;
            MouseYAxis = mouseYAxis;
            FixedTime = fixedTime;
        }
    } 
}
