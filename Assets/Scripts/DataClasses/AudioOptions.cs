using System;
using System.Collections.Generic;

namespace Geekbrains
{
    public class AudioOptions : IOptionsData<float>
    {
        internal static string _totalVolumeKey;

        internal static string _musicVolumeKey;

        internal static string _effectsVolumeKey;

        internal static string _voiceVolumeKey;

        private static string _pathToOptionsFile;

        public event Action<string> parameterChanged;

        private static AudioOptions instance;

        private static readonly object threadlock = new object();
              
        public static AudioOptions Instance
        {
            get
            {
                lock(threadlock)
                {
                    if (instance == null)
                        instance = new AudioOptions();
                    return instance;
                }
            }
        }
        private OptionsParameter<float> _totalVolume = new OptionsParameter<float>(_totalVolumeKey, 1f);

        private OptionsParameter<float> _musicVolume = new OptionsParameter<float>(_musicVolumeKey, 1f);

        private OptionsParameter<float> _effectsVolume = new OptionsParameter<float>(_effectsVolumeKey, 1f);

        private OptionsParameter<float> _voiceVolume = new OptionsParameter<float>(_voiceVolumeKey, 1f);

        private List<object> _volumeParameters;       

        private AudioOptions()
        {
            _volumeParameters = new List<object>();
            _volumeParameters.Add(_totalVolume as object);
            _volumeParameters.Add(_musicVolume as object);
            _volumeParameters.Add(_effectsVolume as object);
            _volumeParameters.Add(_voiceVolume as object);
        }

        public void ChangeParameter(string key, float parameterValue)
        {
            foreach (var parameter in _volumeParameters)
            {
                if(parameter is OptionsParameter<float> && (parameter as OptionsParameter<float>).GetKey.Equals(key))
                {
                    (parameter as OptionsParameter<float>).ChangeValue(parameterValue);
                    parameterChanged.Invoke(key);
                    break;
                }
            }
        }

        public List<object> GetOptions()
        {
            return _volumeParameters;
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