using System;

namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера меню опций
    /// </summary>
    internal class OptionsMenuController : IMenuController
    {
        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса OptionsMenuController (реализация Singletone)
        /// </summary>
        private static OptionsMenuController _instance = null;

        /// <summary>
        /// Свойство для доступа к экзепляру класса OptionsMenuController (реализация Singletone)
        /// </summary>
        internal static OptionsMenuController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new OptionsMenuController();
                return _instance;
            }
        }

        /// <summary>
        /// Поле для хранения ссылки на экземплыр класса OptionsMenuView, отвечающего за отображение меню опций
        /// </summary>
        private OptionsMenuView _optionsMenuView;

        /// <summary>
        /// Событие нажатия на кнопку открывающую меню настроек звука
        /// </summary>
        internal event Action OnClickVolumeSettingsEvent;

        /// <summary>
        /// Событие нажатия на кнопку открывающую меню настроек видео
        /// </summary>
        internal event Action OnClickVideoSettingsEvent;

        /// <summary>
        /// Событие нажатия на кнопку открывающую меню настроек управления
        /// </summary>
        internal event Action OnClickControlSettingsEvent;

        /// <summary>
        /// Событие нажатия на кнопку открывающую меню настроек геймплея
        /// </summary>
        internal event Action OnClickGameplaySettingsEvent;

        /// <summary>
        /// Событие нажатия на кнопку выхода в гланое меню
        /// </summary>
        internal event Action OnClickExitToMainMenuEvent;

        /// <summary>
        /// Метод инициализации ссылки на экземпляр класса OptionsMenuView
        /// </summary>
        /// <param name="optionsMenuView">Ссылка на экземпляр класса отвечающего за отображение</param>
        internal void InitializeView(OptionsMenuView optionsMenuView)
        {
            _optionsMenuView = optionsMenuView;
        }

        /// <summary>
        /// Метод, вызывающий событие нажатия кнопки выхода в главное меню
        /// </summary>
        internal void OpenExitToMainMenu()
        {
            OnClickExitToMainMenuEvent.Invoke();
        }

        /// <summary>
        /// Метод, вызывающий событие нажатия кнопки меню настроек геймплея
        /// </summary>
        internal void OpenGameplaySettings()
        {
            OnClickGameplaySettingsEvent.Invoke();
        }

        /// <summary>
        /// Метод, вызывающий событие нажатия кнопки меню настроек управления
        /// </summary>
        internal void OpenControlSettings()
        {
            OnClickControlSettingsEvent.Invoke();
        }

        /// <summary>
        /// Метод, вызывающий событие нажатия кнопки меню настроек видео
        /// </summary>
        internal void OpenVideoSettings()
        {
            OnClickVideoSettingsEvent.Invoke();
        }

        /// <summary>
        /// Метод, вызывающий событие нажатия кнопки меню настроек звука
        /// </summary>
        internal void OpenVolumeSettings()
        {
            OnClickVolumeSettingsEvent.Invoke();
        }

        /// <summary>
        /// Метод реализующий интерфейс IMenuController (отображение меню)
        /// </summary>
        public void Show()
        {
            _optionsMenuView.Show();
        }

        /// <summary>
        /// Метод реализующий интерфейс IMenuController (скрытие меню)
        /// </summary>
        public void Hide()
        {
            _optionsMenuView.Hide();
        }
    }
}