using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains {
    internal class OptionsMenuView : BaseView
    {
        [SerializeField]
        internal Button volumeSettingsButton;

        [SerializeField]
        internal Button videoSettingsButton;

        [SerializeField]
        internal Button controlSettingsButton;

        [SerializeField]
        internal Button gameplaySettingsButton;

        [SerializeField]
        internal Button exitToMainMenuButton;

        private void Awake()
        {
            _buttonsList.Add(volumeSettingsButton);
            _buttonsList.Add(videoSettingsButton);
            _buttonsList.Add(controlSettingsButton);
            _buttonsList.Add(gameplaySettingsButton);
            _buttonsList.Add(exitToMainMenuButton);
        }
    }
}