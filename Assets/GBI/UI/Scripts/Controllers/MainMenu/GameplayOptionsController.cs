using System.Collections;
using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера меню настроек гейплея
    /// </summary>
    internal class GameplayOptionsController : IMenuController
    {
        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса GameplayOptionsModel
        /// </summary>
        private GameplayOptionsModel _gameplayOptionsModel;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса GameplayMenuView
        /// </summary>
        private GameplayMenuView _gameplayMenuView;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса GameplayOptionsController (реализация Singletone)
        /// </summary>
        private static GameplayOptionsController _instance = null;

        /// <summary>
        /// Свойство для доступа к экземпляру класса GameplayOptionsController (реализация Singletone)
        /// </summary>
        internal static GameplayOptionsController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameplayOptionsController();
                return _instance;
            }
        }

        /// <summary>
        /// Конструктор класса GameplayOptionsController
        /// </summary>
        private GameplayOptionsController()
        {
            _gameplayOptionsModel = GameplayOptionsModel.Instance;
        }

        /// <summary>
        /// Метод инициализации ссылки на экземпляр класса GameplayMenuView
        /// </summary>
        /// <param name="gameplayMenuView"></param>
        internal void InitializeView(GameplayMenuView gameplayMenuView)
        {
            _gameplayMenuView = gameplayMenuView;
        }

        /// <summary>
        /// Метод реализующий интерфейс IMenuController (скрытие меню)
        /// </summary>
        public void Hide()
        {
            _gameplayMenuView.Hide();
        }

        /// <summary>
        /// Метод реализующий интерфейс IMenuController (отображение меню)
        /// </summary>
        public void Show()
        {
            _gameplayMenuView.Show();
        }
    }
}