namespace Geekbrains
{
    /// <summary>
    /// Класс вероятности промаха 
    /// </summary>
    internal sealed class MissProbabilityFeature : SkillFeature
    {
        /// <summary>
        /// Поле, хранящее базовое значения вероятности промаха
        /// </summary>
        private float _missProbability;

        private MissProbabilityFeature() { }

        /// <summary>
        /// Конструктор класса MissProbabilityFeature
        /// </summary>
        /// <param name="missProbability">Базовое значение вероятности промаха</param>
        internal MissProbabilityFeature(float missProbability)
        {
            _missProbability = missProbability;
        }

        /// <summary>
        /// Метод установки базового значения вероятности промаха
        /// </summary>
        /// <param name="value"></param>
        internal override void SetValue(float value)
        {
            _missProbability = value;
        }

        /// <summary>
        /// Метод получения текущего значения вероятности промаха
        /// </summary>
        /// <returns>Текущее значение вероятности промаха</returns>
        internal override float GetValue() => _missProbability * _multiplier;
    }
}