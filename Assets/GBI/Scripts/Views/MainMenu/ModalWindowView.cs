using System;
using UnityEngine;
using UnityEngine.UI;


namespace Geekbrains
{
    public class ModalWindowView : BaseView
    {
        [SerializeField]
        private Button _yesButton;

        [SerializeField]
        private Button _noButton;

        [SerializeField]
        private Text _textPanel;

        private Text _yesButtonTextField;

        private Text _noButtonTextField;

        public string text;

        public string yesButtonText;

        public string noButtonText;

        internal event Action<bool> OnDialogResultEvent;

        protected override void Awake()
        {
            base.Awake();
            _yesButtonTextField = _yesButton.GetComponentInChildren<Text>();
            _noButtonTextField = _noButton.GetComponentInChildren<Text>();
        }

        protected override void Start()
        {
            base.Start();

            _textPanel.text = this.text;
            _yesButtonTextField.text = yesButtonText;
            _noButtonTextField.text = noButtonText;

            _yesButton.onClick.AddListener(() => SetButtonClick(_yesButton));
            _noButton.onClick.AddListener(() => SetButtonClick(_noButton));
        }

        private void SetButtonClick(Button button)
        {
                OnDialogResultEvent.Invoke(button.Equals(_yesButton));
        } 
    }
}