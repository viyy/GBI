using System;
using System.Collections.Generic;

namespace Geekbrains
{
    public class AudioOptionsModel : IOptionsData<float>
    {
        internal string _totalVolumeKey;

        internal string _musicVolumeKey;

        internal string _effectsVolumeKey;

        internal string _voiceVolumeKey;

        internal string _pathToOptionsFile;

        private static AudioOptionsModel instance;

        private OptionsParameter<float> _voiceVolume;

        private OptionsParameter<float> _totalVolume;

        private OptionsParameter<float> _musicVolume;

        private OptionsParameter<float> _effectsVolume;

        private List<object> _volumeParameters;

        public event Action<string> parameterChanged;

        public static AudioOptionsModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new AudioOptionsModel();
                return instance;
            }
        }

        private AudioOptionsModel()
        {
            _totalVolume = new OptionsParameter<float>(_totalVolumeKey, 1f);
            _musicVolume = new OptionsParameter<float>(_musicVolumeKey, 1f);
            _effectsVolume = new OptionsParameter<float>(_effectsVolumeKey, 1f);
            _voiceVolume = new OptionsParameter<float>(_voiceVolumeKey, 1f);

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
    }
}