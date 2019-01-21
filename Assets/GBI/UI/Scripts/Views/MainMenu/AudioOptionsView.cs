using System;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    /// <summary>
    /// Класс, отвечающий за отображение меню настроек звука
    /// </summary>
    internal class AudioOptionsView : BaseView
    {
        /// <summary>
        /// Поле, хранящее ссылку на объект Text, в которое выводится наименование меню
        /// </summary>
        [SerializeField]
        private Text _volumeMenuLabel;

        /// <summary>
        /// Поле, хранящее ключ наименования меню настроек звука
        /// </summary>
        [SerializeField]
        private string _volumeMenuLabelText;

        /// <summary>
        /// Поле, хранящее ссылку на Prefab настроек
        /// </summary>
        [SerializeField]
        private GameObject _volumeOptionsPrefab;

        /// <summary>
        /// Поле, хранящее ссылку на RectTransform поля вывода настроек
        /// </summary>
        [SerializeField]
        private RectTransform _contentPanel;

        /// <summary>
        /// Поле, хранящее ссылку на кнопку установки значений настроек по умолачанию
        /// </summary>
        [SerializeField]
        private Button _defaultButton;

        /// <summary>
        /// Поле, хранящее ссылку на кнопку установки текущих значений настроек
        /// </summary>
        [SerializeField]
        private Button _applyButton;

        /// <summary>
        /// Поле хранящее ссылку на кнопку отмены
        /// </summary>
        [SerializeField]
        private Button _cancelButton;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса AudioOptionsController
        /// </summary>
        private AudioOptionsController _audioOptionsController;

        /// <summary>
        /// Событие запроса данных для отображения
        /// </summary>
        internal event Action OnDataRequestEvent;

        /// <summary>
        /// Переопределение виртуального метода Start() родительского класса для кэширования ссылок
        /// </summary>
        protected override void Start()
        {
            base.Start();
            _audioOptionsController = AudioOptionsController.Instance;
            _cancelButton?.onClick.AddListener(_audioOptionsController.CanceledAudioOptions);
        }

        /// <summary>
        /// Переопределение виртуального метода Show() родительского класса для установки наименования меню
        /// и вызова события запроса данных для отображения
        /// </summary>
        internal override void Show()
        {
            base.Show();
            if(_volumeMenuLabel != null)
                _volumeMenuLabel.text = _volumeMenuLabelText;
            OnDataRequestEvent?.Invoke();
        }

        /// <summary>
        /// Метод установки значений параметров Prefab
        /// </summary>
        /// <param name="nameKey">Ключ наименования параметра</param>
        /// <param name="value">Значение параметра</param>
        internal void SetOptionValue(string nameKey, float value)
        {
            if (_volumeOptionsPrefab != null)
            {
                var parameter = GameObject.Instantiate(_volumeOptionsPrefab);
                parameter.name = nameKey;
                parameter.transform.SetParent(_contentPanel);
                parameter.GetComponent<VolumeOptionsPrefabDataSetup>()?.SetData(nameKey, value);
                var slider = parameter.GetComponentInChildren<Slider>();
                slider?.onValueChanged.AddListener(delegate { _audioOptionsController?.ChangeValueInModel(parameter.name, value); });
            }
        }
    }
}