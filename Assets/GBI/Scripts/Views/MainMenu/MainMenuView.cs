using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    internal class MainMenuView : BaseView
    {
        [SerializeField]
        internal Button newGameButton;

        [SerializeField]
        internal Button loadGameButton;

        [SerializeField]
        internal Button optionsButton;

        [SerializeField]
        internal Button exitButton;

        private void Awake()
        {
            _buttonsList.Add(newGameButton);
            _buttonsList.Add(loadGameButton);
            _buttonsList.Add(optionsButton);
            _buttonsList.Add(exitButton);
        }
    }
}