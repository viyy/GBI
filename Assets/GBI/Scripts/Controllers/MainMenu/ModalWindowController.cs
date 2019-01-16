using System;

namespace Geekbrains
{
    public class ModalWindowController : IMenuController
    {

        private static ModalWindowController _instance = null;

        internal static ModalWindowController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ModalWindowController();
                return _instance;
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
            _modalWindowView.OnDialogResultEvent -= ReturnResult;
        }

        public void Show()
        {
            _modalWindowView.Show();
            _modalWindowView.OnDialogResultEvent += ReturnResult;
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