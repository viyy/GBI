using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public class LoadGameMenuView : BaseView
    {
        [SerializeField]
        private GameObject LoadGameContentPrefab;

        [SerializeField]
        private RectTransform _contentPanel;

        [SerializeField]
        private Button _cancelButton;

        private LoadGameController _loadGameController;

        private Dictionary<Button, int> _locationDictionary;

        public event Action<int> OnClickLocationButton;

        protected override void Start()
        {
            base.Start();
            _loadGameController = LoadGameController.Instance;
            _cancelButton.onClick.AddListener(_loadGameController.CloseLoadGameMenu);
        }

        internal void AddItemInScrollView(int id, string locationName, string detailedInfo, Sprite imageSprite)
        {
            var _itemView = GameObject.Instantiate(LoadGameContentPrefab);
            _itemView.transform.SetParent(_contentPanel);
            _itemView.GetComponent<LoadGamePrefabDataSetup>().SetData(locationName, detailedInfo, imageSprite);
            var _itemButton = _itemView.GetComponentInChildren<Button>();
            _locationDictionary.Add(_itemButton, id);
            _itemButton.onClick.AddListener(() => LoadLocation(_locationDictionary[_itemButton]));
        }

        private void LoadLocation(int id)
        {
            OnClickLocationButton.Invoke(id);
        }

        public override void Show()
        {
            base.Show();
            _loadGameController = LoadGameController.Instance;
        }
    }
}