using System;
using System.Collections.Generic;
using UnityEngine;


namespace Geekbrains
{
    public class LoadGameController : IMenuController
    {
        internal IDataLoader<SaveData> dataLoader;

        private LoadGameModel _loadGameModel;

        private LoadGameMenuView _loadGameMenuView;

        private static LoadGameController instance = null;

        public static LoadGameController Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoadGameController();
                return instance;
            }
        }

        private LoadGameController()
        {
            _loadGameModel = LoadGameModel.Instance;
        }

        public event Action OnClickCancel;

        internal void InitializeView(LoadGameMenuView loadGameMenuView)
        {
            _loadGameMenuView = loadGameMenuView;
        }

        public void Hide()
        {
            _loadGameMenuView.Hide();
        }

        public void Show()
        {
            _loadGameMenuView.Show();
            TransmitDataToView();
        }

        public void CloseLoadGameMenu()
        {
            OnClickCancel.Invoke();
        }

        public void LoadLocation(int id)
        {
            //загрузка соответствующей локации
        }

        private void TransmitDataToView()
        {
            var _loadGameData = _loadGameModel.GetData(dataLoader);

            if (_loadGameData != null)
            {
                while (_loadGameData.Count != 0)
                {
                    var _itemData = _loadGameData.Pop();
                    if (_itemData != null)
                        _loadGameMenuView.AddItemInScrollView(_itemData.id, _itemData.locationKey, _itemData.playerName + "\n" + _itemData.savingDateTime, Resources.Load<Sprite>(_itemData.pathToImage));
                }
            }
            _loadGameMenuView.OnClickLocationButton += LoadLocation;
        }
    }
}