using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    internal class MainMenuView : BaseView
    {
        [SerializeField]
        internal Button newGameButton;

        [SerializeField]
        internal Button loadGameButton;

        [SerializeField]
        internal Button optionsButton;

        [SerializeField]
        internal Button exitButton;

        private MainMenuController _mainMenuController;

        protected override void Awake()
        {
            base.Awake();
            _buttonsList.Add(newGameButton);
            _buttonsList.Add(loadGameButton);
            _buttonsList.Add(optionsButton);
            _buttonsList.Add(exitButton);
        }

        protected override void Start()
        {
            base.Start();
            _mainMenuController = MainMenuController.Instance;
            newGameButton.onClick.AddListener(_mainMenuController.OpenNewGame);
            loadGameButton.onClick.AddListener(_mainMenuController.OpenLoadGame);
            optionsButton.onClick.AddListener(_mainMenuController.OpenOptions);
            exitButton.onClick.AddListener(_mainMenuController.OpenExitGame);
        }
    }
}