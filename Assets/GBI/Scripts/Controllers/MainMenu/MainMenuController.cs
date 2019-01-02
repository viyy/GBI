using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace Geekbrains
{
    internal class MainMenuController : MonoBehaviour, IMenuController
    {
        private static MainMenuController instance = null;

        internal static MainMenuController Instance { get; private set; }

        private MainMenuView _mainMenuView;

        internal event Action OnClickNewGame;

        internal event Action OnClickLoadGame;

        internal event Action OnClickOptions;

        internal event Action OnClickExit;

        private void Start()
        {
            if (Instance)
                DestroyImmediate(this);
            else
                Instance = this;

            _mainMenuView = GetComponent<MainMenuView>();
            _mainMenuView.newGameButton.onClick.AddListener(OpenNewGame);
            _mainMenuView.loadGameButton.onClick.AddListener(OpenLoadGame);
            _mainMenuView.optionsButton.onClick.AddListener(OpenOptions);
            _mainMenuView.exitButton.onClick.AddListener(OpenExitGame);
        }

        private void OnDestroy()
        {
            _mainMenuView.newGameButton.onClick.RemoveListener(OpenNewGame);
            _mainMenuView.loadGameButton.onClick.RemoveListener(OpenLoadGame);
            _mainMenuView.optionsButton.onClick.RemoveListener(OpenOptions);
            _mainMenuView.exitButton.onClick.RemoveListener(OpenExitGame);
        }

        private void OpenNewGame()
        {
            OnClickNewGame.Invoke();
        }

        private void OpenLoadGame()
        {
            OnClickLoadGame.Invoke();
        }

        private void OpenExitGame()
        {
            OnClickExit.Invoke();
        }

        private void OpenOptions()
        {
            OnClickOptions.Invoke();
        }

        public void Hide()
        {
            _mainMenuView.Hide();
        }

        public void Show()
        {
            _mainMenuView.Show();
        }
    }
}