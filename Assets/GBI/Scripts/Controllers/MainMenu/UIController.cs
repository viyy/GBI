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
        private ModalWindowController _modalWindowController;

        [SerializeField]
        internal MainMenuView mainMenuView;

        [SerializeField]
        internal OptionsMenuView optionsMenuView;

        [SerializeField]
        internal NewGameMenuView newGameMenuView;

        [SerializeField]
        internal LoadGameMenuView loadGameMenuView;

        [SerializeField]
        internal ModalWindowView modalWindowView;

        [SerializeField]
        internal AudioOptionsView audioOptionsView;

        private void Awake()
        {
            _mainMenuController = MainMenuController.Instance;
            _optionsMenuController = OptionsMenuController.Instance;
            _newGameController = NewGameController.Instance;
            _loadGameController = LoadGameController.Instance;
            _modalWindowController = ModalWindowController.Instance;
            _audioOptionsController = AudioOptionsController.Instance;
        }

        private void Start()
        {
            _mainMenuController.InitializeView(mainMenuView);
            _optionsMenuController.InitializeView(optionsMenuView);
            _loadGameController.InitializeView(loadGameMenuView);
            _newGameController.InitializeView(newGameMenuView);
            _modalWindowController.InitializeView(modalWindowView);
            _audioOptionsController.InitializeView(audioOptionsView);
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
            _mainMenuController.OnClickNewGame += OpenNewGameMenu;
            _mainMenuController.OnClickExit += OpenModalWindow;
        }

        private void OpenNewGameMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_newGameController));
            _menuSelector.Enable();
            _newGameController.OnClickCancelButton += CloseNewGameMenu;
        }

        private void CloseNewGameMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_newGameController));
            _menuSelector.Disable();
            _newGameController.OnClickCancelButton -= CloseNewGameMenu;
        }

        private void OpenLoadGameMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_loadGameController));
            _menuSelector.Enable();
            _loadGameController.OnClickCancel += CloseLoadGameMenu;
        }

        private void CloseLoadGameMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_loadGameController));
            _menuSelector.Disable();
            _loadGameController.OnClickCancel -= CloseLoadGameMenu;
        }

        private void OpenOptionsMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_mainMenuController));
            _menuSelector.Disable();
            _menuSelector.SetCommand(new ShowHideMenu(_optionsMenuController));
            _menuSelector.Enable();
            _mainMenuController.OnClickOptions -= OpenOptionsMenu;
            _optionsMenuController.OnClickVolumeSettings += OpenVolumeMenu;
            _optionsMenuController.OnClickExitToMainMenu += OpenMainMenu;
        }

        private void OpenVolumeMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_audioOptionsController));
            _menuSelector.Enable();
            _audioOptionsController.OnClickCancelEvent += CloseVolumeMenu;
        }

        private void CloseVolumeMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_audioOptionsController));
            _menuSelector.Disable();
            _audioOptionsController.OnClickCancelEvent -= CloseVolumeMenu;

        }

        private void OpenModalWindow()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_modalWindowController));
            _menuSelector.Enable();
            _modalWindowController.OnDialogResult += ActionAfterExitDialogue;
        }

        private void ActionAfterExitDialogue(bool result)
        {
            if (result)
                Application.Quit();
            else
            {
                _modalWindowController.OnDialogResult -= ActionAfterExitDialogue;
                _menuSelector.Disable();
            }
        }
    }
}