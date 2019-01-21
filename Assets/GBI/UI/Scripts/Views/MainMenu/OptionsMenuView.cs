using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    /// <summary>
    /// Класс, отвечающий за отображение меню опций
    /// </summary>
    internal class OptionsMenuView : BaseView
    {
        /// <summary>
        /// Поле, хранящее ссылку на кнопку меню настроек звука
        /// </summary>
        [SerializeField]
        internal Button volumeSettingsButton;

        /// <summary>
        /// Поле, хранящее ссылку на кнопку меню настроек видео
        /// </summary>
        [SerializeField]
        internal Button videoSettingsButton;

        /// <summary>
        /// Поле, хранящее ссылку на кнопку меню настроек управления
        /// </summary>
        [SerializeField]
        internal Button controlSettingsButton;

        /// <summary>
        /// Поле, хранящее ссылку на кнопку меню настроек геймплея
        /// </summary>
        [SerializeField]
        internal Button gameplaySettingsButton;

        /// <summary>
        /// Поле, хранящее ссылку на кнопку выхода в главное меню
        /// </summary>
        [SerializeField]
        internal Button exitToMainMenuButton;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса OptionsMenuController (контроллер меню опций)
        /// </summary>
        private OptionsMenuController _optionsMenuController;

        /// <summary>
        /// Метод Awake с инициализацией коллекции кнопок (для навигации)
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            _buttonsList.Add(volumeSettingsButton);
            _buttonsList.Add(videoSettingsButton);
            _buttonsList.Add(controlSettingsButton);
            _buttonsList.Add(gameplaySettingsButton);
            _buttonsList.Add(exitToMainMenuButton);
        }

        /// <summary>
        /// Метод Start с подпиской методов контроллера меню опций на события нажатия кнопок меню опций
        /// </summary>
        protected override void Start()
        {
            base.Start();
            _optionsMenuController = OptionsMenuController.Instance;
            volumeSettingsButton?.onClick.AddListener(_optionsMenuController.OpenVolumeSettings);
            videoSettingsButton?.onClick.AddListener(_optionsMenuController.OpenVideoSettings);
            controlSettingsButton?.onClick.AddListener(_optionsMenuController.OpenControlSettings);
            gameplaySettingsButton?.onClick.AddListener(_optionsMenuController.OpenGameplaySettings);
            exitToMainMenuButton?.onClick.AddListener(_optionsMenuController.OpenExitToMainMenu);
        }
    }
}