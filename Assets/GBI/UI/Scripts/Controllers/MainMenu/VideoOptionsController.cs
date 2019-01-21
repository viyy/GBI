namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера меню настроек видео
    /// </summary>
    internal class VideoOptionsController : IMenuController
    {
        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса VideoOptionsModel
        /// </summary>
        private VideoOptionsModel _videoOptionsModel;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса VideoMenuView
        /// </summary>
        private VideoMenuView _videoMenuView;

        /// <summary>
        /// Поле хранящее ссылку на экземпляр класса VideoOptionsController (реализация Singletone)
        /// </summary>
        private static VideoOptionsController _instance = null;

        /// <summary>
        /// Свойство для доступа к экзепляру класса VideoOptionsController (реализация Singletone)
        /// </summary>
        internal static VideoOptionsController Instance
        {
            get
            {
                    if (_instance == null)
                        _instance = new VideoOptionsController();
                    return _instance;
            }
        }

        /// <summary>
        /// Конструктор класса VideoOptionsController
        /// </summary>
        private VideoOptionsController()
        {
            _videoOptionsModel = VideoOptionsModel.Instance;
        }

        /// <summary>
        /// Метод инициализации ссылки на экземпляр класса VideoMenuView
        /// </summary>
        /// <param name="videoMenuView">Сылка на экземпляр класса VideoMenuView</param>
        internal void InitializeView(VideoMenuView videoMenuView)
        {
            _videoMenuView = videoMenuView;
        }

        /// <summary>
        /// Метод реализующий интерфейс IMenuController (отображение меню)
        /// </summary>
        public void Show()
        {
            _videoMenuView?.Show();
        }

        /// <summary>
        /// Метод реализующий интерфейс IMenuController (скрытие меню)
        /// </summary>
        public void Hide()
        {
            _videoMenuView?.Hide();
        }
    }
}
