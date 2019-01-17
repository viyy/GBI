using System;

namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера модального окна
    /// </summary>
    public class ModalWindowController : IMenuController
    {
        /// <summary>
        /// Поле хранящее ссылку на экземпляр класса ModalWindowController (реализация Singletone)
        /// </summary>
        private static ModalWindowController _instance = null;

        /// <summary>
        /// Свойство для доступа к экзепляру класса ModalWindowController (реализация Singletone)
        /// </summary>
        internal static ModalWindowController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ModalWindowController();
                return _instance;
            }
        }

        /// <summary>
        /// Поле хранящее ссылку на экземпляр класса ModalWindowView
        /// </summary>
        private ModalWindowView _modalWindowView;

        /// <summary>
        /// Событие, возвращающее результат диалга с пользователем
        /// </summary>
        internal event Action<bool> OnDialogResultEvent;

        /// <summary>
        /// Метод инициализации ссылки на экземпляр класса ModalWindowView
        /// </summary>
        /// <param name="modalWindowView"></param>
        internal void InitializeView(ModalWindowView modalWindowView)
        {
            _modalWindowView = modalWindowView;
            _modalWindowView.OnDialogResultEvent += ReturnResult;
        }

        /// <summary>
        /// Метод установки текста вопроса к пользователю
        /// </summary>
        /// <param name="text"></param>
        internal void SetModalWindowText(string text)
        {
            _modalWindowView.text = text;
        }

        /// <summary>
        /// Метод реализующий интерфейс IMenuController (скрытие меню)
        /// </summary>
        public void Hide()
        {
            _modalWindowView?.Hide();
        }

        /// <summary>
        /// Метод реализующий интерфейс IMenuController (отображение меню)
        /// </summary>
        public void Show()
        {
            _modalWindowView?.Show();
        }

        private void ReturnResult(bool result)
        {
                OnDialogResultEvent?.Invoke(result);
        }
    }
}