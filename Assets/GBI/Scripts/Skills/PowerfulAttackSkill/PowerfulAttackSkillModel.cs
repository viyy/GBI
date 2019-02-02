namespace Geekbrains
{
    /// <summary>
    /// Класс модели скилла "Мощная атака"
    /// </summary>
    public class PowerfulAttackSkillModel : SkillModel
    {
        /// <summary>
        /// Конструктор класса модели скилла
        /// </summary>
        /// <param name="id">Идентификатор скилла</param>
        public PowerfulAttackSkillModel(int id) : base(id) { }

        /// <summary>
        /// Метод получения значений свойств скилла
        /// </summary>
        /// <typeparam name="T">Интерфейс свойства скилла</typeparam>
        /// <returns>Значение свойства скилла</returns>
        public float GetValue<T>() where T : class, IFeature<float>
        {
            foreach(var feature in _features)
            {
                if(feature is T)
                {
                    return (feature as T).Value;
                }
            }
            return default;
        }
    }
}