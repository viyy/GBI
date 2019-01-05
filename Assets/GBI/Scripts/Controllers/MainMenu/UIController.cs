using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class UIController : MonoBehaviour
    {
        private MenuSelector _menuSelector = new MenuSelector();
        private MainMenuController _mainMenuController;
        private OptionsMenuController _optionsMenuController;
        private NewGameController _newGameController;
        private LoadGameController _loadGameController;
        private AudioOptionsController _audioOptionsController;
        private VideoOptionsController _videoOptionsController;
        private ControlOptionsController _controlOptionsController;
        private GameplayOptionsController _gameplayOptionsController;

        [SerializeField]
        internal MainMenuView mainMenuView;

        [SerializeField]
        internal OptionsMenuView optionsMenuView;

        [SerializeField]
        internal LoadGameMenuView loadGameMenuView;

        private void Awake()
        {
            _mainMenuController = MainMenuController.Instance;
            _optionsMenuController = OptionsMenuController.Instance;
            _loadGameController = LoadGameController.Instance;
            //_audioOptionsController = AudioOptionsController.Instance;
        }

        private void Start()
        {
            _mainMenuController.InitializeView(mainMenuView);
            _optionsMenuController.InitializeView(optionsMenuView);
            _loadGameController.InitializeView(loadGameMenuView);
            OpenMainMenu();
        }

        private void OpenMainMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_optionsMenuController));
            _menuSelector.Disable();
            _menuSelector.SetCommand(new ShowHideMenu(_mainMenuController));
            _menuSelector.Enable();
            _optionsMenuController.OnClickExitToMainMenu -= OpenMainMenu;
            _mainMenuController.OnClickOptions += OpenOptionsMenu;
            _mainMenuController.OnClickLoadGame += OpenLoadGameMenu;
        }

        private void OpenLoadGameMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_loadGameController));
            _menuSelector.Enable();
            _loadGameController.OnClickCancel += CloseLoadGameMenu;
        }

        private void OpenOptionsMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_mainMenuController));
            _menuSelector.Disable();
            _menuSelector.SetCommand(new ShowHideMenu(_optionsMenuController));
            _menuSelector.Enable();
            _mainMenuController.OnClickOptions -= OpenOptionsMenu;
            _optionsMenuController.OnClickExitToMainMenu += OpenMainMenu;
        }

        private void CloseLoadGameMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_loadGameController));
            _menuSelector.Disable();
            _loadGameController.OnClickCancel -= CloseLoadGameMenu;
        }
    }
}