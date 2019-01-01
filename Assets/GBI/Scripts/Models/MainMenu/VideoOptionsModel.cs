using System;
using System.Collections.Generic;

namespace Geekbrains
{
    public class VideoOptions : IOptionsData<ResolutionsEnum>, IOptionsData<QualityEnum>
    {
        internal static string _screenResolutionKey;

        internal static string _textureResolutionKey;

        internal static string _numberOfParticlesKey;

        internal static string _shadowsQualityKey;

        internal static string _drawingRangeKey;

        private static string _pathToOptionsFile;

        internal Dictionary<ResolutionsEnum, string> ResolutionDictionary { get; private set; }

        public event Action<string> parameterChanged;

        private static VideoOptions instance;

        private static readonly object threadlock = new object();

        public static VideoOptions Instance
        {
            get
            {
                lock (threadlock)
                {
                    if (instance == null)
                        instance = new VideoOptions();
                    return instance;
                }
            }
        }
        private OptionsParameter<ResolutionsEnum> _screenResolution = new OptionsParameter<ResolutionsEnum>(_screenResolutionKey, ResolutionsEnum.HD);

        private OptionsParameter<QualityEnum> _textureResolution = new OptionsParameter<QualityEnum>(_textureResolutionKey, QualityEnum.Medium);

        private OptionsParameter<QualityEnum> _numberOfParticles = new OptionsParameter<QualityEnum>(_numberOfParticlesKey, QualityEnum.Medium);

        private OptionsParameter<QualityEnum> _shadowsQuality = new OptionsParameter<QualityEnum>(_shadowsQualityKey, QualityEnum.Medium);

        private OptionsParameter<QualityEnum> _drawingRange = new OptionsParameter<QualityEnum>(_drawingRangeKey, QualityEnum.Medium);

        private List<object> _videoParameters;

        private VideoOptions()
        {
            ResolutionDictionary = new Dictionary<ResolutionsEnum, string>();
            ResolutionDictionary.Add(ResolutionsEnum.XGA, "1024x768");
            ResolutionDictionary.Add(ResolutionsEnum.SVGA, "800x600");
            ResolutionDictionary.Add(ResolutionsEnum.WXGA, "1366x768");
            ResolutionDictionary.Add(ResolutionsEnum.HD, "1280x720");
            ResolutionDictionary.Add(ResolutionsEnum.FHD, "1920x1080");
            ResolutionDictionary.Add(ResolutionsEnum.WUXGA, "1920x1200");
            ResolutionDictionary.Add(ResolutionsEnum.UHD, "3840x2160");

            _videoParameters = new List<object>();
            _videoParameters.Add(_screenResolution as object);
            _videoParameters.Add(_textureResolution as object);
            _videoParameters.Add(_numberOfParticles as object);
            _videoParameters.Add(_shadowsQuality as object);
            _videoParameters.Add(_drawingRange as object);
        }

        public void ChangeParameter(string key, ResolutionsEnum newResolution)
        {
            foreach (var parameter in _videoParameters)
            {
                if (parameter is OptionsParameter<ResolutionsEnum> && (parameter as OptionsParameter<ResolutionsEnum>).GetKey.Equals(key))
                {
                    (parameter as OptionsParameter<ResolutionsEnum>).ChangeValue(newResolution);
                    parameterChanged.Invoke(key);
                    break;
                }
            }
        }

        public void ChangeParameter(string key, QualityEnum newQuality)
        {
            foreach (var parameter in _videoParameters)
            {
                if (parameter is OptionsParameter<QualityEnum> && (parameter as OptionsParameter<QualityEnum>).GetKey.Equals(key))
                {
                    (parameter as OptionsParameter<QualityEnum>).ChangeValue(newQuality);
                    parameterChanged.Invoke(key);
                    break;
                }
            }
        }

        public List<object> GetOptions()
        {
            return _videoParameters;
        }

        public void ReadDataFromFile()
        {
            //вызов метода чтения из файла из класса чтения/записи
        }

        public void WriteDataToFile()
        {
            //вызов метода записи в файл из класса чтения/записи
        }
    }
}

