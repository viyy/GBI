using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    /// <summary>
    /// Класс, отвечающий за отображение меню загрузки игры
    /// </summary>
    internal class LoadGameMenuView : BaseView
    {
        /// <summary>
        /// Поле, хранящее ссылку на Prefab сохраненной игры
        /// </summary>
        [SerializeField]
        private GameObject _loadGameContentPrefab;

        /// <summary>
        /// Поле, хранящее ссылку на RectTransform, в которое выводятся данные о сохраненениях
        /// </summary>
        [SerializeField]
        private RectTransform _contentPanel;

        /// <summary>
        /// Поле, хранящее ссылку на кнопку "Отмена"
        /// </summary>
        [SerializeField]
        private Button _cancelButton;

        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса LoadGameController
        /// </summary>
        private LoadGameController _loadGameController;

        /// <summary>
        /// Словарь соответствий id загрузки соответствующей кнопке
        /// </summary>
        private Dictionary<Button, int> _locationDictionary;

        /// <summary>
        /// Событие при нажатии кнопки, соответствуещей загружаемой локации
        /// </summary>
        public event Action<int> OnClickLocationButtonEvent;

        /// <summary>
        /// Переопределение виртуального метода Start() класса родителя
        /// </summary>
        protected override void Start()
        {
            base.Start();
            _loadGameController = LoadGameController.Instance;
            _cancelButton.onClick.AddListener(_loadGameController.CloseLoadGameMenu);
        }

        /// <summary>
        /// Метод добавления сохраненной игры в поле вывода
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="locationName">Наименование локации</param>
        /// <param name="detailedInfo">Дополнительная информаци о сохраненной игре</param>
        /// <param name="imageSprite">Скриншот сохраненной игры</param>
        internal void AddItemInScrollView(int id, string locationName, string detailedInfo, Sprite imageSprite)
        {
            var _itemView = GameObject.Instantiate(_loadGameContentPrefab);
            _itemView.transform.SetParent(_contentPanel);
            _itemView.GetComponent<LoadGamePrefabDataSetup>().SetData(locationName, detailedInfo, imageSprite);
            var _itemButton = _itemView.GetComponentInChildren<Button>();
            _locationDictionary.Add(_itemButton, id);
            _itemButton.onClick.AddListener(() => LoadLocation(_locationDictionary[_itemButton]));
        }

        /// <summary>
        /// Метод вызывающий событие о нажатии кнопки  загрузки сохраненной игры
        /// </summary>
        /// <param name="id">Идентификатор сохраненной игры</param>
        private void LoadLocation(int id)
        {
            OnClickLocationButtonEvent.Invoke(id);
        }

        /// <summary>
        /// Переопределение метода Show() родительского класса
        /// </summary>
        public override void Show()
        {
            base.Show();
            _loadGameController = LoadGameController.Instance;
        }
    }
}