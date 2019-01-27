namespace Geekbrains
{
    /// <summary>
    /// Класс усталости от применения скилла
    /// </summary>
    internal sealed class FatigueFeature : SkillFeature
    {
        /// <summary>
        /// Базовое значение усталости
        /// </summary>
        private float _fatigue;

        private FatigueFeature() { }

        /// <summary>
        /// Конструктор класса FatigueFeature
        /// </summary>
        /// <param name="fatigue">Базовое значение усталости</param>
        internal FatigueFeature(float fatigue)
        {
            _fatigue = fatigue;
        }

        /// <summary>
        /// Метод установки базового значения усталости
        /// </summary>
        /// <param name="value">Базовое значение усталости</param>
        internal override void SetValue(float value)
        {
            _fatigue = value;
        }

        /// <summary>
        /// Метод, возвращающий текущее значение усталости
        /// </summary>
        /// <returns>Текущее значение усталости</returns>
        internal override float GetValue() => _fatigue * _multiplier;
    }
}
