using System;

namespace Geekbrains {
    internal class OptionsMenuController : IMenuController
    {
        private static OptionsMenuController instance = null;
        
        internal static OptionsMenuController Instance
        {
            get
            {
                if (instance == null)
                    instance = new OptionsMenuController();
                return instance;
            }
        }

        private OptionsMenuView _optionsMenuView;

        internal event Action OnClickVolumeSettings;

        internal event Action OnClickVideoSettings;

        internal event Action OnClickControlSettings;

        internal event Action OnClickGameplaySettings;

        internal event Action OnClickExitToMainMenu;

        private OptionsMenuController() { }

        internal void InitializeView(OptionsMenuView optionsMenuView)
        {
            _optionsMenuView = optionsMenuView;
        }

        internal void OpenExitToMainMenu()
        {
            OnClickExitToMainMenu.Invoke();
        }

        internal void OpenGameplaySettings()
        {
            OnClickGameplaySettings.Invoke();
        }

        internal void OpenControlSettings()
        {
            OnClickControlSettings.Invoke();
        }

        internal void OpenVideoSettings()
        {
            OnClickVideoSettings.Invoke();
        }

        internal void OpenVolumeSettings()
        {
            OnClickVolumeSettings.Invoke();
        }

        public void Show()
        {
            _optionsMenuView.Show();
        }

        public void Hide()
        {
            _optionsMenuView.Hide();
        }
    }
}