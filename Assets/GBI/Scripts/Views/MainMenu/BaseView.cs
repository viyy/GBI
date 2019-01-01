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

        private void Awake()
        {
            _thisObjectCanvas = GetComponent<Canvas>();
        }

        protected virtual void Start()
        {
            Show();
            _buttonsList[_currentButtonIndex]?.Select();
        }

        public void Show()
        {
            _thisObjectCanvas.enabled = true;
        }

        public void Hide()
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