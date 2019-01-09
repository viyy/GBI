using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Geekbrains
{
    public class BaseView : MonoBehaviour
    {
        private Canvas _thisObjectCanvas;

        protected List<Button> _buttonsList;

        private int _currentButtonIndex = 0;

        protected virtual void Awake()
        {
            _buttonsList = new List<Button>();
        }

        protected virtual void Start()
        {
            _thisObjectCanvas = gameObject.GetComponent<Canvas>();

            if(_buttonsList?.Count != 0)
                _buttonsList[_currentButtonIndex]?.Select();
        }

        public virtual void Show()
        {
            _thisObjectCanvas.enabled = true;
        }

        public virtual void Hide()
        {
            _thisObjectCanvas.enabled = false;
        }

        public void SelectNextButton()
        {
            if(_currentButtonIndex < (_buttonsList.Count - 1))
            {
                _currentButtonIndex++;
                _buttonsList[_currentButtonIndex].Select();
            }
        }

        public void SelectPreviousButton()
        {
            if(_currentButtonIndex != 0)
            {
                _currentButtonIndex--;
                _buttonsList[_currentButtonIndex].Select();
            }
        }
    }
}