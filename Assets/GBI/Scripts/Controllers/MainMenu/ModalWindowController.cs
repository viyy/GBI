using System;
using System.Collections.Generic;

namespace Geekbrains
{
    public class ModalWindowController : IMenuController
    {

        private static ModalWindowController instance = null;

        internal static ModalWindowController Instance
        {
            get
            {
                if (instance == null)
                    instance = new ModalWindowController();
                return instance;
            }
        }

        private ModalWindowView _modalWindowView;

        internal event Action<bool> OnDialogResult;

        internal void InitializeView(ModalWindowView modalWindowView)
        {
            _modalWindowView = modalWindowView;
        }

        internal void SetModalWindowText(string text)
        {
            _modalWindowView.text = text;
        }

        public void Hide()
        {
            _modalWindowView.Hide();
            _modalWindowView.OnDialogResult -= ReturnResult;
        }

        public void Show()
        {
            _modalWindowView.Show();
            _modalWindowView.OnDialogResult += ReturnResult;
        }

        private void ReturnResult(bool result)
        {
            if (result)
                OnDialogResult.Invoke(true);
            else
                OnDialogResult.Invoke(false);
        }
    }
}