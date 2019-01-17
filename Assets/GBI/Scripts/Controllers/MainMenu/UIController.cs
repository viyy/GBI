using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Класс главного контроллера пользовательского интерфейса
    /// </summary>
    internal class UIController : MonoBehaviour
    {
        /// <summary>
        /// Поле, хранящее ссылку на селектор команд
        /// </summary>
        private MenuSelector _menuSelector = new MenuSelector();

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса MainMenuController (контроллер главного меню)
        /// </summary>
        private MainMenuController _mainMenuController;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса OptionsMenuController (контроллер меню опций)
        /// </summary>
        private OptionsMenuController _optionsMenuController;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса NewGameController (контроллер меню новой игры)
        /// </summary>
        private NewGameController _newGameController;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса LoadGameController (контроллер меню загрузки сохраненной игры)
        /// </summary>
        private LoadGameController _loadGameController;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса AudioOptionsController (контроллер меню настроек звука)
        /// </summary>
        private AudioOptionsController _audioOptionsController;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса VideoOptionsController (контроллер меню настроек видео)
        /// </summary>
        private VideoOptionsController _videoOptionsController;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса ControlOptionsController (контроллер меню настроек управления)
        /// </summary>
        private ControlOptionsController _controlOptionsController;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса GameplayOptionsController (контроллер меню настроек геймплея)
        /// </summary>
        private GameplayOptionsController _gameplayOptionsController;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса ModalWindowController (контроллер модального окна)
        /// </summary>
        private ModalWindowController _modalWindowController;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса MainMenuView, отвечающего за отображение главного меню
        /// </summary>
        [SerializeField]
        internal MainMenuView MainMenuView;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса OptionsMenuView, отвечающего за отображение меню опций
        /// </summary>
        [SerializeField]
        internal OptionsMenuView OptionsMenuView;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса NewGameMenuView, отвечающего за отображение меню новой игры
        /// </summary>
        [SerializeField]
        internal NewGameMenuView NewGameMenuView;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса LoadGameMenuView, отвечающего за отображение меню загрузки 
        /// сохраненной игры
        /// </summary>
        [SerializeField]
        internal LoadGameMenuView LoadGameMenuView;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса ModalWindowView, отвечающего за отображение модального
        /// диалогового окна
        /// </summary>
        [SerializeField]
        internal ModalWindowView ModalWindowView;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса AudioOptionsView, отвечающего за отображение меню настроек звука
        /// </summary>
        [SerializeField]
        internal AudioOptionsView AudioOptionsView;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса ControlMenuView, отвечающего за отображение меню настроек 
        /// управления
        /// </summary>
        [SerializeField]
        internal ControlMenuView ControlMenuView;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса VideoMenuView, отвечающего за отображение меню настроек видео
        /// </summary>
        [SerializeField]
        internal VideoMenuView VideoMenuView;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса GameplayMenuView, отвечающего за отображение меню настроек геймплея
        /// </summary>
        [SerializeField]
        internal GameplayMenuView GameplayMenuView;

        /// <summary>
        /// Метод инициализации ссылок на контроллеры меню
        /// </summary>
        private void Awake()
        {
            _mainMenuController = MainMenuController.Instance;
            _optionsMenuController = OptionsMenuController.Instance;
            _newGameController = NewGameController.Instance;
            _loadGameController = LoadGameController.Instance;
            _modalWindowController = ModalWindowController.Instance;
            _audioOptionsController = AudioOptionsController.Instance;
            _videoOptionsController = VideoOptionsController.Instance;
            _gameplayOptionsController = GameplayOptionsController.Instance;
            _controlOptionsController = ControlOptionsController.Instance;
        }

        /// <summary>
        /// Метод инициализации классов, отвечающих за отображение соответствующего меню
        /// </summary>
        private void Start()
        {
            _mainMenuController.InitializeView(MainMenuView);
            _optionsMenuController.InitializeView(OptionsMenuView);
            _loadGameController.InitializeView(LoadGameMenuView);
            _newGameController.InitializeView(NewGameMenuView);
            _modalWindowController.InitializeView(ModalWindowView);
            _audioOptionsController.InitializeView(AudioOptionsView);
            _videoOptionsController.InitializeView(VideoMenuView);
            _controlOptionsController.InitializeView(ControlMenuView);
            _gameplayOptionsController.InitializeView(GameplayMenuView);
            OpenMainMenu();
        }

        /// <summary>
        /// Метод отображения главного меню
        /// </summary>
        private void OpenMainMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_optionsMenuController));
            _menuSelector.Disable();
            _menuSelector.SetCommand(new ShowHideMenu(_mainMenuController));
            _menuSelector.Enable();
            _optionsMenuController.OnClickExitToMainMenu -= OpenMainMenu;
            _mainMenuController.OnClickOptionsEvent += OpenOptionsMenu;
            _mainMenuController.OnClickLoadGameEvent += OpenLoadGameMenu;
            _mainMenuController.OnClickNewGameEvent += OpenNewGameMenu;
            _mainMenuController.OnClickExitEvent += OpenModalWindow;
        }

        /// <summary>
        /// Метод отображения меню новой игры
        /// </summary>
        private void OpenNewGameMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_newGameController));
            _menuSelector.Enable();
            _newGameController.OnClickCancelButton += CloseNewGameMenu;
        }

        /// <summary>
        /// Метод закрытия меню новой игры
        /// </summary>
        private void CloseNewGameMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_newGameController));
            _menuSelector.Disable();
            _newGameController.OnClickCancelButton -= CloseNewGameMenu;
        }

        /// <summary>
        /// Метод отображения меню загрузки сохраненной игры
        /// </summary>
        private void OpenLoadGameMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_loadGameController));
            _menuSelector.Enable();
            _loadGameController.OnClickCancelEvent += CloseLoadGameMenu;
        }

        /// <summary>
        /// Метод закрытия меню загрузки сохраненной игры
        /// </summary>
        private void CloseLoadGameMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_loadGameController));
            _menuSelector.Disable();
            _loadGameController.OnClickCancelEvent -= CloseLoadGameMenu;
        }

        /// <summary>
        /// Метод отображения меню опций
        /// </summary>
        private void OpenOptionsMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_mainMenuController));
            _menuSelector.Disable();
            _menuSelector.SetCommand(new ShowHideMenu(_optionsMenuController));
            _menuSelector.Enable();
            _mainMenuController.OnClickOptionsEvent -= OpenOptionsMenu;
            _optionsMenuController.OnClickVolumeSettings += OpenVolumeMenu;
            _optionsMenuController.OnClickExitToMainMenu += OpenMainMenu;
        }

        /// <summary>
        /// Метод отображения меню настроек звука
        /// </summary>
        private void OpenVolumeMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_audioOptionsController));
            _menuSelector.Enable();
            _audioOptionsController.OnClickCancelEvent += CloseVolumeMenu;
        }

        /// <summary>
        /// Метод закрытия меню настроек звука
        /// </summary>
        private void CloseVolumeMenu()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_audioOptionsController));
            _menuSelector.Disable();
            _audioOptionsController.OnClickCancelEvent -= CloseVolumeMenu;

        }

        /// <summary>
        /// Метод отображения модального диалогового окна
        /// </summary>
        private void OpenModalWindow()
        {
            _menuSelector.SetCommand(new ShowHideMenu(_modalWindowController));
            _menuSelector.Enable();
            _modalWindowController.OnDialogResultEvent += ActionAfterExitDialogue;
        }

        /// <summary>
        /// Метод обработки результата диалога о выходе из игры
        /// </summary>
        private void ActionAfterExitDialogue(bool result)
        {
            if (result)
                Application.Quit();
            else
            {
                _modalWindowController.OnDialogResultEvent -= ActionAfterExitDialogue;
                _menuSelector.Disable();
            }
        }
    }
}