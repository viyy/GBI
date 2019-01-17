using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    /// <summary>
    /// Класс установки параметром Prefab сохраненной игры
    /// </summary>
    internal class LoadGamePrefabDataSetup : MonoBehaviour
    {
        /// <summary>
        /// Поле, хранящее ссылку на Text наименования локации сохраненной игры
        /// </summary>
        [SerializeField]
        private Text _locationName;

        /// <summary>
        /// Поле, хранящее ссылку на Text дополнительной информации о сохраненной игре
        /// </summary>
        [SerializeField]
        private Text _detailedInformation;

        /// <summary>
        /// Поле, хранящее ссылку на Image, в которое будет добавляться скриншот сохраненной игры
        /// </summary>
        [SerializeField]
        private Image _locationImage;

        /// <summary>
        /// Метод установки значений для Prefab сохраненной игры
        /// </summary>
        /// <param name="locationName">Наименование локации</param>
        /// <param name="detailedInformation">Дополнительная информаци о сохраненной игре</param>
        /// <param name="imageSprite">Скриншот сохраненной игры</param>
        public void SetData(string locationName, string detailedInformation, Sprite imageSprite)
        {
            _locationName.text = locationName;
            _detailedInformation.text = detailedInformation;
            _locationImage.sprite = imageSprite;
        }
    }
}