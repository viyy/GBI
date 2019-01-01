using UnityEngine;

namespace Geekbrains
{
    public class PauseController : BaseController<PauseModel>
    {
        public PauseController(PauseModel pauseModel) : base(pauseModel) {}

        public bool IsPaused => _model.IsPaused;

        public void Pause()
        {
            Time.timeScale = 0;

            _model.IsPaused = true;

            Cursor.visible = true;
        }

        public void Resume()
        {
            Time.timeScale = 1;

            _model.IsPaused = false;

            Cursor.visible = false;
        }

        public void Switch()
        {
            if ( IsPaused ) {
                Resume();
            } else {
                Pause();
            }
        }
    }
}