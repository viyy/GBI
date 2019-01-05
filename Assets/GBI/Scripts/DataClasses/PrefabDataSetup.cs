using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    internal class PrefabDataSetup : MonoBehaviour
    {
        [SerializeField]
        private Text _locationName;

        [SerializeField]
        private Text _detailedInformation;

        [SerializeField]
        private Image _locationImage;

        public void SetData(string locationName, string detailedInformation, Sprite imageSprite)
        {
            _locationName.text = locationName;
            _detailedInformation.text = detailedInformation;
            _locationImage.sprite = imageSprite;
        }
    }
}