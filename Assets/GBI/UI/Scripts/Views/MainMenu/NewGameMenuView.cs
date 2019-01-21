using System;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    /// <summary>
    /// Класс отвечающий за отображение меню новой игры
    /// </summary>
    internal class NewGameMenuView : BaseView
    {
        /// <summary>
        /// Поле, хранящее ссылку на кнопку начала новой игры
        /// </summary>
        [SerializeField]
        private Button _startButton;

        /// <summary>
        /// Поле, хранящее ссылку на кнопку отмены
        /// </summary>
        [SerializeField]
        private Button _cancelButton;

        /// <summary>
        /// Поле, хранящее ссылку на слайдер выбора сложности игры
        /// </summary>
        [SerializeField]
        private Slider _difficaltySlider;

        /// <summary>
        /// Поле, хранящее ссылку на поле ввода имени игрока
        /// </summary>
        [SerializeField]
        private InputField _playerNameIF;

        /// <summary>
        /// Поле, хранящее ссылку на перелистывание в панели выбора персонажа влево
        /// </summary>
        [SerializeField]
        private Button _toLeftButton;

        /// <summary>
        /// Поле, хранящее ссылку на перелистывание в панели выбора персонажа вправо
        /// </summary>
        [SerializeField]
        private Button _toRightButton;

        /// <summary>
        /// Поле, хранящее ссылку на панель отображения спрайта персонажа
        /// </summary>
        [SerializeField]
        private Image _characterImage;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса NewGameController (контроллер меню новой игры)
        /// </summary>
        private NewGameController _newGameController;

        /// <summary>
        /// Событие запуска новой игры возвращающее имя игрока и сложность игры 
        /// </summary>
        internal event Action<string, int> OnClickStartButtonEvent;

        /// <summary>
        /// Метод Start, осуществляющий подписку методов контроллера на нажатия кнопок и изменение положения слайдера
        /// </summary>
        protected override void Start()
        {
            base.Start();
            _newGameController = NewGameController.Instance;
            _startButton?.onClick.AddListener(() => StartNewGame(_playerNameIF.text, (int)_difficaltySlider.value));
            _cancelButton?.onClick.AddListener(_newGameController.CloseNewGameMenu);
            _playerNameIF?.onValueChanged.AddListener(SetStartButtonInteractable);
        }

        /// <summary>
        /// Метод вызывающий событие начала новой игры
        /// </summary>
        /// <param name="playerName">Имя игрока</param>
        /// <param name="difficalty">Сложность игры</param>
        /// <param name="character">Выбранный персонаж</param>
        private void StartNewGame(string playerName, int difficalty)
        {
            OnClickStartButtonEvent?.Invoke(playerName, difficalty);
        }

        /// <summary>
        /// Метод отображения спрайты персонажа в поле выбора персонажа
        /// </summary>
        /// <param name="characterSprite">Спрайт персонажа</param>
        internal void ShowCharacterSprite(Sprite characterSprite)
        {
            if(_characterImage != null)
                _characterImage.sprite = characterSprite;
        }

        /// <summary>
        /// Метод активации кнопки начала игры только при заполненном поле ввода имени игрока
        /// </summary>
        /// <param name="text">Введенный в поле имени игрока текст</param>
        private void SetStartButtonInteractable(string text)
        {
            if(_startButton != null)
                _startButton.interactable = text != String.Empty;
        }
    }
}