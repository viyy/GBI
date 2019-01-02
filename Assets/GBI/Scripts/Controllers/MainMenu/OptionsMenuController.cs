using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains {
    internal class OptionsMenuController : MonoBehaviour, IMenuController
    {
        private static OptionsMenuController instance = null;
        
        internal static OptionsMenuController Instance { get; private set; }

        private OptionsMenuView _optionsMenuView;

        internal event Action OnClickVolumeSettings;

        internal event Action OnClickVideoSettings;

        internal event Action OnClickControlSettings;

        internal event Action OnClickGameplaySettings;

        internal event Action OnClickExitToMainMenu;

        private void Awake()
        {
            if (Instance)
                DestroyImmediate(this);
            else
                Instance = this;

            _optionsMenuView = GetComponent<OptionsMenuView>();

            _optionsMenuView.volumeSettingsButton.onClick.AddListener(OpenVolumeSettings);
            _optionsMenuView.videoSettingsButton.onClick.AddListener(OpenVideoSettings);
            _optionsMenuView.controlSettingsButton.onClick.AddListener(OpenControlSettings);
            _optionsMenuView.gameplaySettingsButton.onClick.AddListener(OpenGameplaySettings);
            _optionsMenuView.exitToMainMenuButton.onClick.AddListener(OpenExitToMainMenu);
        }

        private void OpenExitToMainMenu()
        {
            OnClickExitToMainMenu.Invoke();
        }

        private void OpenGameplaySettings()
        {
            OnClickGameplaySettings.Invoke();
        }

        private void OpenControlSettings()
        {
            OnClickControlSettings.Invoke();
        }

        private void OpenVideoSettings()
        {
            OnClickVideoSettings.Invoke();
        }

        private void OpenVolumeSettings()
        {
            OnClickVolumeSettings.Invoke();
        }

        private void OnDestroy()
        {
            _optionsMenuView.volumeSettingsButton.onClick.RemoveListener(OpenVolumeSettings);
            _optionsMenuView.videoSettingsButton.onClick.RemoveListener(OpenVideoSettings);
            _optionsMenuView.controlSettingsButton.onClick.RemoveListener(OpenControlSettings);
            _optionsMenuView.gameplaySettingsButton.onClick.RemoveListener(OpenGameplaySettings);
            _optionsMenuView.exitToMainMenuButton.onClick.RemoveListener(OpenExitToMainMenu);
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