using System;
using System.Collections.Generic;

namespace Geekbrains
{
    public class VideoOptionsModel : IOptionsData<int>
    {
        internal static string _screenResolutionKey;

        internal static string _textureResolutionKey;

        internal static string _numberOfParticlesKey;

        internal static string _shadowsQualityKey;

        internal static string _drawingRangeKey;

        private static string _pathToOptionsFile;

        internal Dictionary<ResolutionsEnum, string> ResolutionDictionary { get; private set; }

        public event Action<string> parameterChanged;

        private static VideoOptionsModel instance;

        public static VideoOptionsModel Instance
        {
            get
            {
                    if (instance == null)
                        instance = new VideoOptionsModel();
                    return instance;
            }
        }
        private OptionsParameter<int> _screenResolution = new OptionsParameter<int>(_screenResolutionKey, (int)ResolutionsEnum.HD);

        private OptionsParameter<int> _textureResolution = new OptionsParameter<int>(_textureResolutionKey, (int)QualityEnum.Medium);

        private OptionsParameter<int> _numberOfParticles = new OptionsParameter<int>(_numberOfParticlesKey, (int)QualityEnum.Medium);

        private OptionsParameter<int> _shadowsQuality = new OptionsParameter<int>(_shadowsQualityKey, (int)QualityEnum.Medium);

        private OptionsParameter<int> _drawingRange = new OptionsParameter<int>(_drawingRangeKey, (int)QualityEnum.Medium);

        private List<OptionsParameter<int>> _videoParameters;

        private VideoOptionsModel()
        {
            ResolutionDictionary = new Dictionary<ResolutionsEnum, string>();
            ResolutionDictionary.Add(ResolutionsEnum.XGA, "1024x768");
            ResolutionDictionary.Add(ResolutionsEnum.SVGA, "800x600");
            ResolutionDictionary.Add(ResolutionsEnum.WXGA, "1366x768");
            ResolutionDictionary.Add(ResolutionsEnum.HD, "1280x720");
            ResolutionDictionary.Add(ResolutionsEnum.FHD, "1920x1080");
            ResolutionDictionary.Add(ResolutionsEnum.WUXGA, "1920x1200");
            ResolutionDictionary.Add(ResolutionsEnum.UHD, "3840x2160");

            _videoParameters = new List<OptionsParameter<int>>();
            _videoParameters.Add(_screenResolution);
            _videoParameters.Add(_textureResolution);
            _videoParameters.Add(_numberOfParticles);
            _videoParameters.Add(_shadowsQuality);
            _videoParameters.Add(_drawingRange);
        }

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

        public List<OptionsParameter<int>> GetOptions()
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

