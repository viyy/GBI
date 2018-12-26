namespace Geekbrains
{
    public class PauseModel : BaseModel
    {
        private bool _isPaused;

        public bool IsPaused
        {
            get { return _isPaused; }
            set { _isPaused = value; }
        }
    }
}