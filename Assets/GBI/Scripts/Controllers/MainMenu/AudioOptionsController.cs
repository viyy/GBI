using System.Collections.Generic;

namespace Geekbrains
{
    public class AudioOptionsController : IMenuController
    {
        internal IDataLoader<OptionsParameter<float>> dataLoader;

        internal string pathToData;

        private AudioOptionsModel _audioOptionsModel;

        internal AudioOptionsView audioOptionsView;

        private static AudioOptionsController instance = null;
        public static AudioOptionsController Instance
        {
            get
            {
                    if (instance == null)
                        instance = new AudioOptionsController();
                    return instance;
            }
        }

        private AudioOptionsController()
        {
            _audioOptionsModel = AudioOptionsModel.Instance;
            //audioOptionsView.audioOptionsController = this;
            //audioOptionsView.dataRequestEvent += TransmitAudioOptions;
            var data = ReadDataFromFile();
            if (data != null)
                _audioOptionsModel.SetData(data);
        }

        public void Show()
        {
            audioOptionsView.Show();
        }

        public void Hide()
        {
            audioOptionsView.Hide();
        }

        private void TransmitAudioOptions()
        {
            var parametersList = _audioOptionsModel.GetOptions();
            foreach (var parameter in parametersList)
            {
                audioOptionsView.SetOptionValue(parameter.GetKey, parameter.GetValue);
            }
        }

        public void ChangeValueInModel(string name,  float newValue)
        {
            _audioOptionsModel.ChangeParameter(name, newValue);
        } 

        public List<OptionsParameter<float>> ReadDataFromFile()
        {
            return dataLoader.LoadDataToList(pathToData);
        }

        public void WriteDataToFile()
        {
            //вызов метода записи в файл из класса чтения/записи
        }
    }
}

