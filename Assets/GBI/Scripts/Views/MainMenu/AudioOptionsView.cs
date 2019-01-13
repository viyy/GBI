using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public class AudioOptionsView : BaseView
    {
        [SerializeField]
        private Text _volumeMenuLabel;

        [SerializeField]
        private string _volumeMenuLabelText;

        [SerializeField]
        private GameObject _volumeOptionsPrefab;

        [SerializeField]
        private RectTransform _contentPanel;

        [SerializeField]
        private Button _defaultButton;

        [SerializeField]
        private Button _applyButton;

        [SerializeField]
        private Button _cancelButton;

        private AudioOptionsController _audioOptionsController;

        internal event Action dataRequestEvent;

        protected override void Start()
        {
            base.Start();
            _audioOptionsController = AudioOptionsController.Instance;
            _cancelButton.onClick.AddListener(_audioOptionsController.CanceledAudioOptions);
        }

        public override void Show()
        {
            base.Show();
            _volumeMenuLabel.text = _volumeMenuLabelText;
            dataRequestEvent.Invoke();
        }

        public void SetOptionValue(string nameKey, float value)
        {
            var parameter = GameObject.Instantiate(_volumeOptionsPrefab);
            parameter.name = nameKey;
            parameter.transform.SetParent(_contentPanel);
            parameter.GetComponent<OptionsPrefabDataSetup>().SetData(nameKey, value);
            var slider = parameter.GetComponentInChildren<Slider>();
            slider.onValueChanged.AddListener(delegate { _audioOptionsController.ChangeValueInModel(parameter.name, value); });
        }
    }
}