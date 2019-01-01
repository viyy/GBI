namespace Geekbrains
{
    /// <summary>
    /// Класс свойств скилла <br/>
    /// Каждый объект характеристики добавляет скиллу особые свойства 
    /// </summary>
    public class SkillFeature
    {
        /// <summary>
        /// Скилл работает по области
        /// </summary>
        public bool IsAOE;

        /// <summary>
        /// Скилл - аура <br/>
        /// Можно объединить с IsAOE
        /// </summary>
        public bool IsAura;

        /// <summary>
        /// Сколько урона наносит эта часть скилла <br/>
        /// Негативное значение запускает процесс исцеления
        /// </summary>
        public float Damage;
    }
}