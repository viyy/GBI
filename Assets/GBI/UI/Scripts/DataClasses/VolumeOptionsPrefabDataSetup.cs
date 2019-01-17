using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    /// <summary>
    /// Класс, реализующий настройку параметров Prefab с двумя текстовыми полями и слайдером в режиме float
    /// </summary>
    internal class VolumeOptionsPrefabDataSetup : MonoBehaviour
    {
        /// <summary>
        /// Поле, хранящее ссылку на Text, в которое выводится наименование параметра
        /// </summary>
        [SerializeField]
        private Text _optionLabel;

        /// <summary>
        /// Поле, хранящее ссылку на Text, в которое выводится значение параметра
        /// </summary>
        [SerializeField]
        private Text _optionValue;

        /// <summary>
        /// Поле, хрянящее ссылку на Slider
        /// </summary>
        [SerializeField]
        private Slider _optionSlider;

        /// <summary>
        /// Множитель для отображения в процентах от номинала
        /// </summary>
        private const int multiplier = 100;

        /// <summary>
        /// Метод установки наименования и значений параметра
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetData(string name, float value)
        {
            _optionLabel.text = name;
            _optionValue.text = (value * multiplier).ToString();
            _optionSlider.value = value;
        }
    }
}