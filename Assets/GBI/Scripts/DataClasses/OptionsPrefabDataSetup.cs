using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public class OptionsPrefabDataSetup : MonoBehaviour
    {
        [SerializeField]
        private Text _optionLabel;

        [SerializeField]
        private Text _optionValue;

        [SerializeField]
        private Slider _optionSlider;

        public void SetData(string name, float value)
        {
            _optionLabel.text = name;
            _optionValue.text = value.ToString();
            _optionSlider.value = value;
        }
    }
}