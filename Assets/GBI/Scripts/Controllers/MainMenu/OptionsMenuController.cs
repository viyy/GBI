using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains {
    public class OptionsMenuController : MonoBehaviour
    {
        private static OptionsMenuController instance = null;

        private static readonly object threadlock = new object();

        internal AudioOptionsController _audioOptionsController;

        internal VideoOptionsController _videoOptionsController;
        
        public static OptionsMenuController Instance { get; private set; }

        [SerializeField]
        private Button _audioOptionsButton;

        [SerializeField]
        private Button _videoOptionsButton;

        private void Awake()
        {
            if (Instance)
                DestroyImmediate(this);
            else
                Instance = this;
        }

        private void Start()
        {
            _audioOptionsController = AudioOptionsController.Instance;
            _videoOptionsController = VideoOptionsController.Instance;
        }
    }
}