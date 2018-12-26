using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace Geekbrains
{
    public class MainMenuController : MonoBehaviour
    {

        #region Fields

        [Header("Menu Extensions")]
        [SerializeField]
        private Canvas _loadGameMenuExtension;

        [SerializeField]
        private Canvas _optionsMenuExtension;

        [SerializeField]
        private Canvas _newGameMenuExtension;

        [Header("Menus")]
        [SerializeField]
        private Canvas _mainMenu;

        [SerializeField]
        private GameObject _firstSelectedItemMainMenu;

        [SerializeField]
        private Canvas _optionsMenu;

        [SerializeField]
        private GameObject _firstSelectedItemOptionsMenu;

        private List<Canvas> _extensionMenus = new List<Canvas>();

        #endregion

        private void Start()
        {
            _extensionMenus.Add(_loadGameMenuExtension);
            _extensionMenus.Add(_optionsMenuExtension);
            _extensionMenus.Add(_newGameMenuExtension);
        }

        public void OpenNewGameMenu()
        {
            EnableMenuExtension(_newGameMenuExtension);
        }

        public void OpenLoadGameMenu()
        {
            EnableMenuExtension(_loadGameMenuExtension);
        }

        public void OpenOptionsMenu()
        {
            EnableMenuExtension(_optionsMenuExtension);
            _mainMenu.enabled = false;
            _optionsMenu.enabled = true;
            SetCurrentSelectedMenuItem(_firstSelectedItemOptionsMenu);
        }

        public void OpenMainMenu()
        {
            DisableAllMenuExtension();
            _optionsMenu.enabled = false;
            _mainMenu.enabled = true;
            SetCurrentSelectedMenuItem(_firstSelectedItemMainMenu);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
        
        private void EnableMenuExtension(Canvas menuExtension)
        {
            foreach(var menu in _extensionMenus)
            {
                if (menu != null)
                {
                    
                    if (menu == menuExtension)
                    {
                        menu.enabled = true;
                    }
                    else
                        menu.enabled = false;
                }
            }
        }

        private void DisableAllMenuExtension()
        {
            foreach (var menu in _extensionMenus) menu.enabled = false;
        }

        private void SetCurrentSelectedMenuItem (GameObject item)
        {
            EventSystem.current.SetSelectedGameObject(item);
        }
    }
}