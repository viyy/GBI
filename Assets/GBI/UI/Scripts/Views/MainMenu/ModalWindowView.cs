using System;
using UnityEngine;
using UnityEngine.UI;


namespace Geekbrains
{
    /// <summary>
    /// Класс, отвечающий за отображение модального диалогового окна
    /// </summary>
    internal class ModalWindowView : BaseView
    {
        /// <summary>
        /// Поле, хранящее ссылку на кнопку положительного ответа
        /// </summary>
        [SerializeField]
        private Button _yesButton;

        /// <summary>
        /// Поле, хранящее ссылку на кнопку отрицательного ответа
        /// </summary>
        [SerializeField]
        private Button _noButton;

        /// <summary>
        /// Поле, хранящее ссылу на Text, в котором отображается текст вопроса
        /// </summary>
        [SerializeField]
        private Text _textPanel;

        /// <summary>
        /// Поле, хранящее ссылу на Text, в котором отображается текст кнопки положительного ответа
        /// </summary>
        private Text _yesButtonTextField;

        /// <summary>
        /// Поле, хранящее ссылу на Text, в котором отображается текст кнопки отрицательного ответа
        /// </summary>
        private Text _noButtonTextField;

        /// <summary>
        /// Поле, хранящее текст вопроса
        /// </summary>
        public string text;

        /// <summary>
        /// Поле, хранящее текст положительного ответа
        /// </summary>
        public string yesButtonText;

        /// <summary>
        /// Поле, хранящее текст отрицательного ответа
        /// </summary>
        public string noButtonText;

        /// <summary>
        /// Событие возвращающее результат диалога с пользователем
        /// </summary>
        internal event Action<bool> OnDialogResultEvent;

        /// <summary>
        /// Переопределение виртуального метода Awake() базового класса
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            _yesButtonTextField = _yesButton?.GetComponentInChildren<Text>();
            _noButtonTextField = _noButton?.GetComponentInChildren<Text>();
        }

        /// <summary>
        /// Переопределение виртуального метода Start() базового класса
        /// </summary>
        protected override void Start()
        {
            base.Start();

            if(_textPanel != null)
                _textPanel.text = this.text;

            if (_yesButton != null)
            _yesButtonTextField.text = yesButtonText;

            if (_yesButton != null)
                _noButtonTextField.text = noButtonText;

            _yesButton?.onClick.AddListener(() => SetButtonClick(_yesButton));
            _noButton?.onClick.AddListener(() => SetButtonClick(_noButton));
        }

        /// <summary>
        /// Метод вызывающий событие результата диалога
        /// </summary>
        private void SetButtonClick(Button button)
        {
            if(button != null)
                OnDialogResultEvent?.Invoke(button.Equals(_yesButton));
        } 
    }
}