namespace Geekbrains
{
    /// <summary>
    /// Класс урона скила
    /// </summary>
    internal class DamageFeature : SkillFeature
    {
        /// <summary>
        /// Поле, хранящее величину урона
        /// </summary>
        private float _damage;

        private DamageFeature() { }

        /// <summary>
        /// Конструктор класса DamageFeature
        /// </summary>
        /// <param name="damage">Базовая виличина урона</param>
        internal DamageFeature(float damage)
        {
            _damage = damage;
        }

        internal override void SetValue(float value)
        {
            _damage = value;
        }

        /// <summary>
        /// Метод, получения текущего значения урона
        /// </summary>
        /// <returns>Текущее значение урона</returns>
        internal override float GetValue() => _damage * _multiplier;
    }
}