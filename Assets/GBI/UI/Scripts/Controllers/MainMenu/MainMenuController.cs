using System;

namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера главного меню
    /// </summary>
    internal class MainMenuController : IMenuController
    {
        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса MainMenuView, отвечающего за отображение главного меню
        /// </summary>
        private MainMenuView _mainMenuView;

        /// <summary>
        /// Событие нажатия на кнопку открытия меню новой игры
        /// </summary>
        internal event Action OnClickNewGameEvent;

        /// <summary>
        /// Событие нажатия на кнопку открытия меню загрузки сохраненной игры
        /// </summary>
        internal event Action OnClickLoadGameEvent;

        /// <summary>
        /// Событие нажатия на кнопку открытия меню опций
        /// </summary>
        internal event Action OnClickOptionsEvent;

        /// <summary>
        /// Событие нажатия на кнопку выхода из игры
        /// </summary>
        internal event Action OnClickExitEvent;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса MainMenuController (реализация Singletone)
        /// </summary>
        private static MainMenuController _instance = null;

        /// <summary>
        /// Свойство для доступа к экзепляру класса MainMenuController (реализация Singletone)
        /// </summary>
        internal static MainMenuController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainMenuController();
                return _instance;
            }
        }

        /// <summary>
        /// Конструктор класса MainMenuController
        /// </summary>
        private MainMenuController() { }

        /// <summary>
        /// Метод инициализации ссылки на экземпляр класса MainMenuView
        /// </summary>
        /// <param name="mainMenuView">Ссылка на экземпляр класса, отвечающего за отображение главного меню</param>
        internal void InitializeView(MainMenuView mainMenuView)
        {
            _mainMenuView = mainMenuView;
        }

        /// <summary>
        /// Метод, вызывающий событие для отображения меню новой игры
        /// </summary>
        internal void OpenNewGame()
        {
            OnClickNewGameEvent?.Invoke();
        }

        /// <summary>
        /// Метод, вызывающий событие для отображения меню загрузки ишры
        /// </summary>
        internal void OpenLoadGame()
        {
            OnClickLoadGameEvent?.Invoke();
        }

        /// <summary>
        /// Метод, вызывающий событие для отображения меню опций
        /// </summary>
        internal void OpenOptions()
        {
            OnClickOptionsEvent?.Invoke();
        }

        /// <summary>
        /// Метод, вызывающий событие для открытия модального диалогового окна 
        /// </summary>
        internal void OpenExitGame()
        {
            OnClickExitEvent?.Invoke();
        }

        /// <summary>
        /// Метод, реализующий интерфейс IMenuController (скрытие меню)
        /// </summary>
        public void Hide()
        {
            _mainMenuView?.Hide();
        }

        /// <summary>
        /// Метод, реализующий интерфейс IMenuController (отображение меню)
        /// </summary>
        public void Show()
        {
            _mainMenuView?.Show();
        }
    }
}