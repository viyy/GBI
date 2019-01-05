using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class ShowHideMenu : IMenuCommand
    {
        private IMenuController _menuController;

        internal ShowHideMenu(IMenuController menuController)
        {
            _menuController = menuController;
        }

        public void Enable()
        {
            _menuController.Show();
        }

        public void Disable()
        {
            _menuController.Hide();
        }
    }
}