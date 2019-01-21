using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    /// <summary>
    /// Класс, отвечающий за отображение главного меню
    /// </summary>
    internal class MainMenuView : BaseView
    {
        /// <summary>
        /// Поле, хранящее ссылку на кнопку открытия меню новой игры
        /// </summary>
        [SerializeField]
        internal Button newGameButton;

        /// <summary>
        /// Поле, хранящее ссылку на кнопку открытия меню загрузки сохраненной игры
        /// </summary>
        [SerializeField]
        internal Button loadGameButton;

        /// <summary>
        /// Поле, хранящее ссылку на кнопку открытия меню опций
        /// </summary>
        [SerializeField]
        internal Button optionsButton;

        /// <summary>
        /// Поле, хранящее ссылку на кнопку выхода из игры
        /// </summary>
        [SerializeField]
        internal Button exitButton;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса MainMenuController (контроллер главного меню)
        /// </summary>
        private MainMenuController _mainMenuController;

        /// <summary>
        /// Метод Awake заполняющий коллекцию кнопок главного меню (для навигации)
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            _buttonsList.Add(newGameButton);
            _buttonsList.Add(loadGameButton);
            _buttonsList.Add(optionsButton);
            _buttonsList.Add(exitButton);
        }

        /// <summary>
        /// Метод Start реализующий подписку методов контроллера на нажатия кнопок
        /// </summary>
        protected override void Start()
        {
            base.Start();
            _mainMenuController = MainMenuController.Instance;
            newGameButton?.onClick.AddListener(_mainMenuController.OpenNewGame);
            loadGameButton?.onClick.AddListener(_mainMenuController.OpenLoadGame);
            optionsButton?.onClick.AddListener(_mainMenuController.OpenOptions);
            exitButton?.onClick.AddListener(_mainMenuController.OpenExitGame);
        }
    }
}