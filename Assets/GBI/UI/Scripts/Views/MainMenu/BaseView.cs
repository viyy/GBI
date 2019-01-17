using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Geekbrains
{
    /// <summary>
    /// Класс отвечающий за отображение меню (базовый)
    /// </summary>
    internal class BaseView : MonoBehaviour
    {
        /// <summary>
        /// Поле, хранящее ссылку на Canvas меню
        /// </summary>
        private Canvas _thisObjectCanvas;

        /// <summary>
        /// Поле, хранящее ссылку на коллекцию кнопок меню
        /// </summary>
        protected List<Button> _buttonsList;

        /// <summary>
        /// Поле, хранящее индекс текущей активной кнопки меню
        /// </summary>
        private int _currentButtonIndex = 0;

        /// <summary>
        /// Виртуальный метод Awake для инициализации коллекции кнопок меню
        /// </summary>
        protected virtual void Awake()
        {
            _buttonsList = new List<Button>();
        }

        /// <summary>
        /// Виртуальный метод Start для наполнения коллекции кнопок меню кэширования ссылки на Canvas меню
        /// </summary>
        protected virtual void Start()
        {
            _thisObjectCanvas = gameObject.GetComponent<Canvas>();

            if(_buttonsList?.Count != 0)
                _buttonsList[_currentButtonIndex]?.Select();
        }

        /// <summary>
        /// Виртуальный метод отображения меню
        /// </summary>
        internal virtual void Show()
        {
            _thisObjectCanvas.enabled = true;
        }

        /// <summary>
        /// Виртуальный метод скрытия меню
        /// </summary>
        internal virtual void Hide()
        {
            _thisObjectCanvas.enabled = false;
        }

        /// <summary>
        /// Метод перемещения на следующую кнопку (навигация)
        /// </summary>
        internal void SelectNextButton()
        {
            if(_currentButtonIndex < (_buttonsList.Count - 1))
            {
                _currentButtonIndex++;
                _buttonsList[_currentButtonIndex].Select();
            }
        }

        /// <summary>
        /// Метод перемещения на предыдущую кнопку (навигация)
        /// </summary>
        internal void SelectPreviousButton()
        {
            if(_currentButtonIndex != 0)
            {
                _currentButtonIndex--;
                _buttonsList[_currentButtonIndex].Select();
            }
        }
    }
}