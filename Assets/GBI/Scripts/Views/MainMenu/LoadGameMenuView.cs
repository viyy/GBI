using System.Collections;
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
        private Button _loadButton;

        [SerializeField]
        private Button _cancelButton;

        private LoadGameController _loadGameController;

        protected override void Awake()
        {
        }

        protected override void Start()
        {
            base.Start();
        }

        internal void AddItemInScrollView(string locationName, string detailedInfo, Sprite imageSprite)
        {
            var _itemView = GameObject.Instantiate(LoadGameContentPrefab);
            _itemView.transform.SetParent(_contentPanel);
            _itemView.GetComponent<PrefabDataSetup>().SetData(locationName, detailedInfo, imageSprite);
        }

        public override void Show()
        {
            base.Show();
            _loadGameController = LoadGameController.Instance;
            _cancelButton.onClick.AddListener(_loadGameController.CloseLoadGameMenu);
        }
    }
}