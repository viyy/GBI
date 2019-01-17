using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Класс модели меню настроек видео
    /// </summary>
    internal class VideoOptionsModel : IOptionsData<int>
    {
        /// <summary>
        /// Поле, хранящее ключ для именования опции разрешения экрана
        /// </summary>
        internal string ScreenResolutionKey;

        /// <summary>
        /// Поле, хранящее ключ для именования опции качества текстур
        /// </summary>
        internal string TextureResolutionKey;

        /// <summary>
        /// Поле, хранящее ключ для именования опции количества частиц
        /// </summary>
        internal string NumberOfParticlesKey;

        /// <summary>
        /// Поле, хранящее ключ для именования опции качества теней
        /// </summary>
        internal string ShadowsQualityKey;

        /// <summary>
        /// Поле, хранящее ключ для именования опции глубины прорисовки
        /// </summary>
        internal string DrawingRangeKey;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса VideoOptionsModel (реализация Singletone)
        /// </summary>
        private static VideoOptionsModel _instance = null;

        /// <summary>
        /// Свойство для доступа к экзепляру класса VideoOptionsModel (реализация Singletone)
        /// </summary>
        public static VideoOptionsModel Instance
        {
            get
            {
                    if (_instance == null)
                        _instance = new VideoOptionsModel();
                    return _instance;
            }
        }

        /// <summary>
        /// Поле, хранящее текущие значения опции разрешения экрана
        /// </summary>
        private OptionsParameter<int> _screenResolution;

        /// <summary>
        /// Поле, хранящее текущие значения опции качества текстур
        /// </summary>
        private OptionsParameter<int> _textureResolution;

        /// <summary>
        /// Поле, хранящее текущие значения опции количества частиц
        /// </summary>
        private OptionsParameter<int> _numberOfParticles;

        /// <summary>
        /// Поле, хранящее текущие значения опции качества теней
        /// </summary>
        private OptionsParameter<int> _shadowsQuality;

        /// <summary>
        /// Поле, хранящее текущие значения опции глубины прорисовки
        /// </summary>
        private OptionsParameter<int> _drawingRange;

        /// <summary>
        /// Коллекция текущих значений настроек видео
        /// </summary>
        private List<OptionsParameter<int>> _videoParameters;

        /// <summary>
        /// Конструктор класса VideoOptionsModel
        /// </summary>
        private VideoOptionsModel()
        {
            SetDefaultData();

            _videoParameters = new List<OptionsParameter<int>>();
            _videoParameters.Add(_screenResolution);
            _videoParameters.Add(_textureResolution);
            _videoParameters.Add(_numberOfParticles);
            _videoParameters.Add(_shadowsQuality);
            _videoParameters.Add(_drawingRange);
        }

        /// <summary>
        /// Метод установки значения параметра видео (реализация интерфейса IOptionsData)
        /// </summary>
        /// <param name="key">Ключ параметра</param>
        /// <param name="newValue"> Новое значение параметра</param>
        public void ChangeParameter(string key, int newValue)
        {
            foreach (var parameter in _videoParameters)
            {
                if (parameter.GetKey.Equals(key))
                {
                    parameter.ChangeValue(newValue);
                    break;
                }
            }
        }

        /// <summary>
        /// Метод установки значений параметров видео по умолчанию
        /// </summary>
        internal void SetDefaultData()
        {
            _screenResolution = new OptionsParameter<int>(ScreenResolutionKey, (int)ResolutionsEnum.HD);
            _textureResolution = new OptionsParameter<int>(TextureResolutionKey, (int)QualityEnum.Medium);
            _numberOfParticles = new OptionsParameter<int>(NumberOfParticlesKey, (int)QualityEnum.Medium);
            _shadowsQuality = new OptionsParameter<int>(ShadowsQualityKey, (int)QualityEnum.Medium);
            _drawingRange = new OptionsParameter<int>(DrawingRangeKey, (int)QualityEnum.Medium);
        }

        /// <summary>
        /// Метод, возвращающий коллекцию текущих параметров видео (реализация интерфейса IOptionsData)
        /// </summary>
        /// <returns>Ссылка на коллекцию текущих параметров видео</returns>
        public List<OptionsParameter<int>> GetOptions()
        {
            return _videoParameters;
        }
    }
}

