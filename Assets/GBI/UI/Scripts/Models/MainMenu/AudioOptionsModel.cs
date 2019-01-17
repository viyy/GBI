using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Класс модели меню настроек звука
    /// </summary>
    internal class AudioOptionsModel : IOptionsData<float>
    {
        /// <summary>
        /// Поле, хранящее ключ для именования опции общей громкости
        /// </summary>
        internal string MasterVolumeKey;

        /// <summary>
        /// Поле, хранящее ключ для именования опции громкости музыки
        /// </summary>
        internal string MusicVolumeKey;

        /// <summary>
        /// Поле, хранящее ключ для именования опции громкости эффектов
        /// </summary>
        internal string EffectsVolumeKey;

        /// <summary>
        /// Поле, хранящее ключ для именования опции громкости озвучки
        /// </summary>
        internal string VoiceVolumeKey;

        /// <summary>
        /// Поле, хранящее текущее значение громкости озвучки
        /// </summary>
        private OptionsParameter<float> _voiceVolume;

        /// <summary>
        /// Поле, хранящее текущее значение общей громкости
        /// </summary>
        private OptionsParameter<float> _masterVolume;

        /// <summary>
        /// Поле, хранящее текущее значение громкости музыки
        /// </summary>
        private OptionsParameter<float> _musicVolume;

        /// <summary>
        /// Поле, хранящее текущее значение громкости эффектов
        private OptionsParameter<float> _effectsVolume;

        /// <summary>
        /// Поле, хранящее ссылку на коллекцию текущих параметров звука
        /// </summary>
        private List<OptionsParameter<float>> _volumeParameters;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса AudioOptionsModel (реализация Singletone)
        /// </summary>
        private static AudioOptionsModel _instance = null;

        /// <summary>
        /// Свойство для доступа к ссылке на экземпляр класса AudioOptionsModel (реализация Singletone)
        /// </summary>
        public static AudioOptionsModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AudioOptionsModel();
                return _instance;
            }
        }

        /// <summary>
        /// Конструктор класса AudioOptionsModel
        /// </summary>
        private AudioOptionsModel()
        {
            SetDefaultData();

            _volumeParameters = new List<OptionsParameter<float>>();
            _volumeParameters.Add(_masterVolume);
            _volumeParameters.Add(_musicVolume);
            _volumeParameters.Add(_effectsVolume);
            _volumeParameters.Add(_voiceVolume);
        }

        /// <summary>
        /// Метод установки значений параметров звука класса AudioOptionsModel
        /// </summary>
        /// <param name="parametersList">Ссылка на коллекцию параметров звука</param>
        internal void SetData(List<OptionsParameter<float>> parametersList)
        {
            _volumeParameters = parametersList;
        }

        /// <summary>
        /// Метод установки значения параметра звука (реализация интерфейса IOptionsData)
        /// </summary>
        /// <param name="key">Ключ параметра</param>
        /// <param name="parameterValue"> Новое значение параметра</param>
        public void ChangeParameter(string key, float parameterValue)
        {
            foreach (var parameter in _volumeParameters)
            {
                if(parameter.GetKey.Equals(key))
                {
                    parameter.ChangeValue(parameterValue);
                    break;
                }
            }
        }

        /// <summary>
        /// Метод установки значений параметров звука по умолчанию
        /// </summary>
        internal void SetDefaultData()
        {
            MasterVolumeKey = "Master Volume";
            MusicVolumeKey = "Music Volume";
            EffectsVolumeKey = "Effects Volume";
            VoiceVolumeKey = "Voice Volume";
            _masterVolume = new OptionsParameter<float>(MasterVolumeKey, 1f);
            _musicVolume = new OptionsParameter<float>(MusicVolumeKey, 1f);
            _effectsVolume = new OptionsParameter<float>(EffectsVolumeKey, 1f);
            _voiceVolume = new OptionsParameter<float>(VoiceVolumeKey, 1f);
        }

        /// <summary>
        /// Метод возвращающий коллекцию текущих параметров звука (реализация интерфейса IOptionsData)
        /// </summary>
        /// <returns>Ссылка на коллекцию текущих параметров звука</returns>
        public List<OptionsParameter<float>> GetOptions()
        {
            return _volumeParameters;
        }
    }
}