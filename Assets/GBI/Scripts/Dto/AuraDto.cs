using System.Collections.Generic;
using GBI.Utility;

namespace Geekbrains.Skills
{
    /// <summary>
    /// Класс для передачи данных об аурах
    /// </summary>
    public class AuraDto
    {
        public int Id { get; set; }
        /// <summary>
        /// Тип ауры
        /// </summary>
        public AuraTypes Type { get; set; }
        /// <summary>
        /// Название ауры
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отображается-ли аура в интерфейсе
        /// </summary>
        public bool IsVisible { get; set; }
        /// <summary>
        /// Является-ли аура постоянной/можно ли её снять самому
        /// </summary>
        public bool IsPermanent { get; set; }
        /// <summary>
        /// Длительность действия
        /// </summary>
        public float Duration { get; set; }
        /// <summary>
        /// путь к иконке эффекта
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// Коэффициенты для характеристик.
        /// </summary>
        public SerializableDictionary<CharacteristicTypes, float> Values { get; set; } = new SerializableDictionary<CharacteristicTypes, float>();
    }
}