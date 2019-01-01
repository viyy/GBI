using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера паузы
    /// </summary>
    /// <see cref="BaseController{T}"/> <br/>
    /// <see cref="PauseModel"/>
    public class PauseController : BaseController<PauseModel>
    {
        public PauseController(PauseModel pauseModel) : base(pauseModel) { }

        /// <summary>
        /// Свойство для получения текущего состояния паузы
        /// </summary>
        public bool IsPaused => _model.IsPaused;

        /// <summary>
        /// Метод установки паузы в игре
        /// </summary>
        public void Pause()
        {
            Time.timeScale = 0;

            _model.IsPaused = true;

            Cursor.visible = true;
        }

        /// <summary>
        /// Метод снятия паузы в игре
        /// </summary>
        public void Resume()
        {
            Time.timeScale = 1;

            _model.IsPaused = false;

            Cursor.visible = false;
        }

        /// <summary>
        /// Метод переключения состояний паузы
        /// </summary>
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