using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Geekbrains
{
    public class MainMenuView : BaseView
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
        }

        protected override void Start()
        {
            base.Start();
        }       
    }
}