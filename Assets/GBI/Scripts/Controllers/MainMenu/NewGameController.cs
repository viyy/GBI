using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Geekbrains {
    internal class NewGameController : IMenuController
    {
        private NewGameMenuView _newGameMenuView;

        private static NewGameController _instance = null;

        internal event Action<string, int, CharacterEnum> OnClickStartNewGame;

        internal event Action OnClickCancelButton;

        private CharacterEnum _currentCharacter = 0;

        private readonly int _numberOfCharacters = Enum.GetValues(typeof(CharacterEnum)).Length;

        public static NewGameController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NewGameController();
                return _instance;
            }
        }

        internal void InitializeView(NewGameMenuView newGameMenuView)
        {
            _newGameMenuView = newGameMenuView;
        }

        internal void StartNewGame(string playerName, int selectedDifficalty)
        {
            OnClickStartNewGame.Invoke(playerName, selectedDifficalty, _currentCharacter);
        }

        internal void CloseNewGameMenu()
        {
            OnClickCancelButton.Invoke();
        }

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

            _newGameMenuView.ShowCharacterSprite(GetCharacterSprite(_currentCharacter));
        }

        private Sprite GetCharacterSprite(CharacterEnum currentCharacter)
        {
            //загрузка спрайта персонажа
            return null;
        }

        public void Hide()
        {
            _newGameMenuView.Hide();
            _currentCharacter = 0;
        }

        public void Show()
        {
            _newGameMenuView.Show();
            _newGameMenuView.ShowCharacterSprite(GetCharacterSprite(_currentCharacter));
        }



    }
}