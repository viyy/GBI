using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains {
    internal class OptionsMenuView : BaseView
    {
        [SerializeField]
        internal Button volumeSettingsButton;

        [SerializeField]
        internal Button videoSettingsButton;

        [SerializeField]
        internal Button controlSettingsButton;

        [SerializeField]
        internal Button gameplaySettingsButton;

        [SerializeField]
        internal Button exitToMainMenuButton;

        private OptionsMenuController _optionsMenuController;

        protected override void Awake()
        {
            base.Awake();
            _buttonsList.Add(volumeSettingsButton);
            _buttonsList.Add(videoSettingsButton);
            _buttonsList.Add(controlSettingsButton);
            _buttonsList.Add(gameplaySettingsButton);
            _buttonsList.Add(exitToMainMenuButton);
        }

        protected override void Start()
        {
            base.Start();
            _optionsMenuController = OptionsMenuController.Instance;
            volumeSettingsButton.onClick.AddListener(_optionsMenuController.OpenVolumeSettings);
            videoSettingsButton.onClick.AddListener(_optionsMenuController.OpenVideoSettings);
            controlSettingsButton.onClick.AddListener(_optionsMenuController.OpenControlSettings);
            gameplaySettingsButton.onClick.AddListener(_optionsMenuController.OpenGameplaySettings);
            exitToMainMenuButton.onClick.AddListener(_optionsMenuController.OpenExitToMainMenu);
        }
    }
}