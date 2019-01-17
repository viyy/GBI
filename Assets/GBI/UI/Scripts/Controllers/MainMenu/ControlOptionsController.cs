using System.Collections;
using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера меню настроек управления
    /// </summary>
    internal class ControlOptionsController : IMenuController
    {
        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса ControlOptionsModel
        /// </summary>
        private ControlOptionsModel _controlOptionsModel;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса ControlMenuView
        /// </summary>
        private ControlMenuView _controlMenuView;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса ControlOptionsController (реализация Singletone)
        /// </summary>
        private static ControlOptionsController _instance = null;

        /// <summary>
        /// Свойство для доступа к экземпляру класса ControlOptionsController (реализация Singletone)
        /// </summary>
        internal static ControlOptionsController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ControlOptionsController();
                return _instance;
            }
        }

        /// <summary>
        /// Конструктор класса ControlOptionsController
        /// </summary>
        private ControlOptionsController()
        {
            _controlOptionsModel = ControlOptionsModel.Instance;
        }

        /// <summary>
        /// Метод инициализации ссылки на экземпляр класса ControlMenuView
        /// </summary>
        /// <param name="gameplayMenuView"></param>
        internal void InitializeView(ControlMenuView controlMenuView)
        {
            _controlMenuView = controlMenuView;
        }

        /// <summary>
        /// Метод реализующий интерфейс IMenuController (скрытие меню)
        /// </summary>
        public void Hide()
        {
            _controlMenuView?.Hide();
        }

        /// <summary>
        /// Метод реализующий интерфейс IMenuController (отображение меню)
        /// </summary>
        public void Show()
        {
            _controlMenuView?.Show();
        }
    }
}