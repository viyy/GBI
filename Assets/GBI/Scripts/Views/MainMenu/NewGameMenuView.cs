using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public class NewGameMenuView : BaseView
    {
        [SerializeField]
        private Button _startButton;

        [SerializeField]
        private Button _cancelButton;

        [SerializeField]
        private Slider _difficaltySlider;

        [SerializeField]
        private InputField _playerNameIF;

        [SerializeField]
        private Button _toLeftButton;

        [SerializeField]
        private Button _toRightButton;

        [SerializeField]
        private Image _characterImage;

        private NewGameController _newGameController;

        internal event Action<string, int> OnClickStartButton;

        protected override void Start()
        {
            base.Start();
            _newGameController = NewGameController.Instance;
            _startButton.onClick.AddListener(() => StartNewGame(_playerNameIF.text, (int)_difficaltySlider.value));
            _cancelButton.onClick.AddListener(_newGameController.CloseNewGameMenu);
        }

        private void StartNewGame(string playerName, int difficalty)
        {
            OnClickStartButton.Invoke(playerName, difficalty);
        }

        internal void ShowCharacterSprite(Sprite characterSprite)
        {
            _characterImage.sprite = characterSprite;
        }
    }
}