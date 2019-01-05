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

        private List<OptionsParameter<float>> _volumeParameters;


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
            SetDefaultData();

            _volumeParameters = new List<OptionsParameter<float>>();
            _volumeParameters.Add(_totalVolume);
            _volumeParameters.Add(_musicVolume);
            _volumeParameters.Add(_effectsVolume);
            _volumeParameters.Add(_voiceVolume);
        }

        public void SetData(List<OptionsParameter<float>> parametersList)
        {
            _volumeParameters = parametersList;
        }

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

        internal void SetDefaultData()
        {
            _totalVolume = new OptionsParameter<float>(_totalVolumeKey, 1f);
            _musicVolume = new OptionsParameter<float>(_musicVolumeKey, 1f);
            _effectsVolume = new OptionsParameter<float>(_effectsVolumeKey, 1f);
            _voiceVolume = new OptionsParameter<float>(_voiceVolumeKey, 1f);
        }

        public List<OptionsParameter<float>> GetOptions()
        {
            return _volumeParameters;
        }
    }
}