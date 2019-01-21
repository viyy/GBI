using System;
using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера меню новой игры
    /// </summary>
    internal class NewGameController : IMenuController
    {
        /// <summary>
        /// Поле, хранящее текущего персонажа выбранного пользователем
        /// </summary>
        private CharacterEnum _currentCharacter = 0;

        /// <summary>
        /// Поле, хранящее длинну перечесления персонажей
        /// </summary>
        private readonly int _numberOfCharacters = Enum.GetValues(typeof(CharacterEnum)).Length;

        /// <summary>
        /// Поле, хранящее ссылку на класс NewGameMenuView, отвечающий за отображение меню новой игры
        /// </summary>
        private NewGameMenuView _newGameMenuView;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса NewGameController (реализация Singletone)
        /// </summary>
        private static NewGameController _instance = null;

        /// <summary>
        /// Событие нажатия кнопки начала новой игры, передающее имя игрока, сложность игры и выбранного персонажа
        /// </summary>
        internal event Action<string, int, CharacterEnum> OnClickStartNewGame;

        /// <summary>
        /// Событие нажатия кнопки отмены
        /// </summary>
        internal event Action OnClickCancelButton;

        /// <summary>
        /// Свойство для доступа к экзепляру класса NewGameController (реализация Singletone)
        /// </summary>
        public static NewGameController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NewGameController();
                return _instance;
            }
        }

        /// <summary>
        /// Конструктор класса NewGameController
        /// </summary>
        private NewGameController() { }

        /// <summary>
        /// Метод инициализации ссылки на экземпляр класса NewGameMenuView
        /// </summary>
        /// <param name="newGameMenuView">Ссылка на экзепляр класса, отвечающего за отображение меню новой игры</param>
        internal void InitializeView(NewGameMenuView newGameMenuView)
        {
            _newGameMenuView = newGameMenuView;
        }

        /// <summary>
        /// Метод вызывающий событие нажатия на кнопку начала игры
        /// </summary>
        /// <param name="playerName">Имя игрока</param>
        /// <param name="selectedDifficalty">Выбранная сложность игры</param>
        internal void StartNewGame(string playerName, int selectedDifficalty)
        {
            OnClickStartNewGame?.Invoke(playerName, selectedDifficalty, _currentCharacter);
        }

        /// <summary>
        /// Метод, вызывающий собтие нажатия на кнопку отмены
        /// </summary>
        internal void CloseNewGameMenu()
        {
            OnClickCancelButton?.Invoke();
        }

        /// <summary>
        /// Метод смены текущего выбранного пользователем персонажа
        /// </summary>
        /// <param name="direction">Направление перемещения</param>
        internal void ChangeCharacter(ChangerEnum direction)
        {
            var character = (int)_currentCharacter;

            switch (direction)
            {
                case ChangerEnum.Increase:
                    if (character == _numberOfCharacters - 1)
                        character = 0;
                    else
                        character++;
                    _currentCharacter = (CharacterEnum)character;
                    break;

                case ChangerEnum.Decrease:
                    if (character == 0)
                        character = _numberOfCharacters - 1;
                    else
                        character--;
                    _currentCharacter = (CharacterEnum)character;
                    break;
            }

            _newGameMenuView?.ShowCharacterSprite(GetCharacterSprite(_currentCharacter));
        }

        /// <summary>
        /// Метод загрузки спрайта персонажа
        /// </summary>
        /// <param name="currentCharacter">Текущий выбранный пользователем персонаж</param>
        /// <returns>Спрайт персонажа</returns>
        private Sprite GetCharacterSprite(CharacterEnum currentCharacter)
        {
            //загрузка спрайта персонажа
            return null;
        }

        /// <summary>
        /// Метод реализующий интерфейс IMenuController (скрытие меню)
        /// </summary>
        public void Hide()
        {
            _newGameMenuView?.Hide();
            _currentCharacter = 0;
        }

        /// <summary>
        /// Метод реализующий интерфейс IMenuController (скрытие меню)
        /// </summary>
        public void Show()
        {
            _newGameMenuView?.Show();
            _newGameMenuView?.ShowCharacterSprite(GetCharacterSprite(_currentCharacter));
        }
    }
}