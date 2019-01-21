using System;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера меню загрузки игры
    /// </summary>
    internal class LoadGameController : IMenuController
    {
        /// <summary>
        /// Поле, хранящее ссылку на загрузчик сохраненных игр, реализующий интерфейс IDataLoader
        /// </summary>
        internal IDataLoader<SaveData> DataLoader;

        /// <summary>
        /// Поле, хранящее ссылку на класс LoadGameModel
        /// </summary>
        private LoadGameModel _loadGameModel;

        /// <summary>
        /// Поле, хранящее ссылку на класс LoadGameMenuView
        /// </summary>
        private LoadGameMenuView _loadGameMenuView;

        /// <summary>
        /// Поле, хранящее ссылку на стэк сохраненных игр
        private Stack<SaveData> _loadGameData;

        /// <summary>
        /// Событие при нажатии кнопки отмены
        /// </summary>
        internal event Action OnClickCancelEvent;

        /// <summary>
        /// Поле хранящее ссылку на экземпляр класса LoadGameController (реализация Singletone)
        /// </summary>
        private static LoadGameController _instance = null;

        /// <summary>
        /// Свойство для доступа к экзепляру класса LoadGameController (реализация Singletone)
        /// </summary>
        public static LoadGameController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LoadGameController();
                return _instance;
            }
        }

        /// <summary>
        /// Конструктор класса LoadGameController
        /// </summary
        private LoadGameController()
        {
            _loadGameModel = LoadGameModel.Instance;
        }

        /// <summary>
        /// Метод инициализации ссылки на экземпляр класса LoadGameMenuView
        /// </summary>
        /// <param name="loadGameMenuView">Ссылка на экземпляр класса отвечающего за отображение</param>
        internal void InitializeView(LoadGameMenuView loadGameMenuView)
        {
            _loadGameMenuView = loadGameMenuView;
        }

        /// <summary>
        /// Метод реализующий интерфейс IMenuController (скрытие меню)
        /// </summary>
        public void Hide()
        {
            _loadGameMenuView?.Hide();
        }

        /// <summary>
        /// Метод реализующий интерфейс IMenuController (отображение меню)
        /// </summary>
        /// <exception cref="NullReferenceException">Ошибка при счтывании данных о сохраненифх</exception>
        public void Show()
        {
            if (_loadGameData == null)
                _loadGameData = _loadGameModel?.GetData(DataLoader);
            _loadGameMenuView?.Show();
            try
            {
                TransmitDataToView();
            }
             catch(NullReferenceException ex)
            {
                Debug.Log("При загрузке данных произошла ошибка");
            }
        }

        /// <summary>
        /// Метод вызывающий событие при нажатии кнопки отмены
        /// </summary>
        internal void CloseLoadGameMenu()
        {
            OnClickCancelEvent?.Invoke();
        }

        /// <summary>
        /// Метод загрузки сохраненной игры
        /// </summary>
        /// <param name="id"></param>
        public void LoadLocation(int id)
        {
            //загрузка соответствующей локации
        }

        /// <summary>
        /// Метод передачи данных для отображения в меню
        /// </summary>
        private void TransmitDataToView()
        {
            while (_loadGameData.Count != 0)
            {
                var _itemData = _loadGameData.Pop();
                if (_itemData != null)
                    _loadGameMenuView?.AddItemInScrollView(_itemData.id, _itemData.locationKey, _itemData.playerName + "\n" + _itemData.savingDateTime, Resources.Load<Sprite>(_itemData.pathToImage));
            }
            if (_loadGameMenuView != null)
                _loadGameMenuView.OnClickLocationButtonEvent += LoadLocation;
        }
    }
}