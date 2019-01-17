using System;
using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера меню настроек звука
    /// </summary>
    internal class AudioOptionsController : IMenuController
    {
        /// <summary>
        /// Поле для хранения ссылки на класс реализующий интерфейс IDataLoader
        /// </summary>
        internal IDataLoader<OptionsParameter<float>> DataLoader;

       /// <summary>
       /// Поле для хранения ссылки на источник данных
       /// </summary>
        internal string PathToData;

        /// <summary>
        /// Поле для хранения ссылки на модель меню настроек звука
        /// </summary>
        private AudioOptionsModel _audioOptionsModel;

        /// <summary>
        /// Поле для хранения ссылки на view меню настроек звука
        /// </summary>
        private AudioOptionsView _audioOptionsView;

        /// <summary>
        /// Событие нажатия кнопки "Отмена"
        /// </summary>
        internal event Action OnClickCancelEvent;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса AudioOptionsController (реализация Singletone)
        /// </summary>
        private static AudioOptionsController _instance = null;

        /// <summary>
        /// Свойство для доступа к экзепляру класса AudioOptionsController (реализация Singletone)
        /// </summary>
        internal static AudioOptionsController Instance
        {
            get
            {
                    if (_instance == null)
                        _instance = new AudioOptionsController();
                    return _instance;
            }
        }

        /// <summary>
        /// Конструктор класса AudioOptionsController
        /// </summary>
        private AudioOptionsController()
        {
            _audioOptionsModel = AudioOptionsModel.Instance;
        }

        /// <summary>
        /// Метод инициализации ссылки на экземпляр класса AudioOptionsView и установки начальных параметров
        /// </summary>
        /// <param name="audioOptionsView">Сылка на на экземпляр класса AudioOptionsView</param>
        internal void InitializeView(AudioOptionsView audioOptionsView)
        {
            _audioOptionsView = audioOptionsView;
            if (_audioOptionsView != null)
                _audioOptionsView.OnDataRequestEvent += TransmitAudioOptions;
            var data = ReadDataFromSource();
            if (data != null)
                _audioOptionsModel?.SetData(data);
        }


        /// <summary>
        /// Метод реализующий интерфейс IMenuController (отображение меню)
        /// </summary>
        public void Show()
        {
            _audioOptionsView?.Show();
        }

        /// <summary>
        /// Метод реализующий интерфейс IMenuController (скрытие меню)
        /// </summary>
        public void Hide()
        {
            _audioOptionsView?.Hide();
        }

        /// <summary>
        /// Метод передачи данных из экземпляра класса AudioOptionsModel в экземпляр класса AudioOptionsView
        /// </summary>
        private void TransmitAudioOptions()
        {
            var parametersList = _audioOptionsModel?.GetOptions();
            foreach (var parameter in parametersList)
            {
                _audioOptionsView?.SetOptionValue(parameter.GetKey, parameter.GetValue);
            }
            _audioOptionsView.OnDataRequestEvent -= TransmitAudioOptions;
        }

        /// <summary>
        /// Метод изменения данных в классе AudioOptionsModel
        /// </summary>
        /// <param name="name">Ключ параметра</param>
        /// <param name="newValue">Значение параметра</param>
        internal void ChangeValueInModel(string name,  float newValue)
        {
            _audioOptionsModel?.ChangeParameter(name, newValue);
        }

        /// <summary>
        /// Метод считывания данных из источника
        /// </summary>
        /// <returns>Ссылка на коллекцию параметров OptionsParameter</returns>
        internal List<OptionsParameter<float>> ReadDataFromSource()
        {
            return DataLoader?.LoadDataToList(PathToData);
        }

        /// <summary>
        /// Метод, вызывающий событие OnClickCancel
        /// </summary>
        internal void CanceledAudioOptions()
        {
            OnClickCancelEvent?.Invoke();
        }
    }
}

