namespace Geekbrains
{
    /// <summary>
    /// Класс свойств скилла <br/>
    /// Каждый объект характеристики добавляет скиллу особые свойства 
    /// </summary>
    public abstract class SkillFeature
    {
        /// <summary>
        /// Поле, хранящее множитель (для применения мутогенов и временных скилов)
        /// </summary>
        protected float _multiplier = 1f;

        /// <summary>
        /// Скилл работает по области
        /// </summary>
        //public bool IsAOE;

        /// <summary>
        /// Скилл - аура <br/>
        /// Можно объединить с IsAOE
        /// </summary>
        //public bool IsAura;

        /// <summary>
        /// Сколько урона наносит эта часть скилла <br/>
        /// Негативное значение запускает процесс исцеления
        /// </summary>
        //public float Damage;

        /// <summary>
        /// Метод установки множителя свойства скилла
        /// </summary>
        /// <param name="multiplier">Величина множителя</param>
        internal virtual void SetMultiplier(float multiplier)
        {
            _multiplier = multiplier;
        }

        /// <summary>
        /// Метод установки базового значения свойства скилла
        /// </summary>
        /// <param name="value">Базовое значение фичи</param>
        internal abstract void SetValue(float value);

        /// <summary>
        /// Метод получения текущего значения свойства скилла
        /// </summary>
        /// <returns>Текущее значение фичи</returns>
        internal abstract float GetValue();
    }
}