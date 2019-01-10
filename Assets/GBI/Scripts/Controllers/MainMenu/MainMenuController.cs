using System;

namespace Geekbrains
{
    internal class MainMenuController : IMenuController
    {
        private static MainMenuController instance = null;

        internal static MainMenuController Instance
        {
            get
            {
                if (instance == null)
                   instance = new MainMenuController();
                return instance;
            }
        }

        private MainMenuController() { }

        private MainMenuView _mainMenuView;

        internal event Action OnClickNewGame;

        internal event Action OnClickLoadGame;

        internal event Action OnClickOptions;

        internal event Action OnClickExit;

        internal void InitializeView(MainMenuView mainMenuView)
        {
            _mainMenuView = mainMenuView;
        }

        internal void OpenNewGame()
        {
            OnClickNewGame.Invoke();
        }

        internal void OpenLoadGame()
        {
            OnClickLoadGame.Invoke();
        }

        internal void OpenExitGame()
        {
            OnClickExit.Invoke();
        }

        internal void OpenOptions()
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