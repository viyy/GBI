using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Класс модели скилла "Мощная атака"
    /// </summary>
    internal sealed class PowerfulAttackSkillModel : SkillModel
    {
        /// <summary>
        /// Поле, хранящее ссылку на коллекцию фич "Мощной атаки"
        /// </summary>
        internal List<SkillFeature> SkillFeatures;

        /// <summary>
        /// Поле, хранящее значение урона по-умолчанию
        /// </summary>
        private const float _damageDefault = 5f;

        /// <summary>
        /// Поле, хранящее значение вероятности промаха по-умолчанию
        /// </summary>
        private const float _missProbabilityDefault = 0.5f;

        /// <summary>
        /// Поле, хранящее значение усталости по-умолчанию
        /// </summary>
        private const float _fatigueDefault = 5f;

        /// <summary>
        /// Поле, хранящее ссылку на класс события запроса данных DataRequestEvent
        /// </summary>

        /// <summary>
        /// Конструктор класса PowerfulAttackSkillModel
        /// </summary>
        /// <param name="id">Идентификатор скилла</param>
        internal PowerfulAttackSkillModel(int id) : base(id)
        {
            LoadDefault();

            SkillFeatures = DispatchEventWithResult<DataRequestEvent, List<SkillFeature>>(new DataRequestEvent(this));

            for (int i = 0; i < SkillFeatures.Count; i++)
            {
                if (SkillFeatures[i] != null)
                    Register(SkillFeatures[i]);
            }
        }

        /// <summary>
        /// Метод установки множителя для соответствующего свойства скилла
        /// </summary>
        /// <typeparam name="T">Тип свойства скилла</typeparam>
        /// <param name="multiplier">Значение множителя</param>
        internal void SetMultiplier<T>(float multiplier) where T : SkillFeature
        {
            for(int i=0; i < _features.Count; i++)
            {
                if(_features[i] is T)
                {
                    _features[i].SetMultiplier(multiplier);
                    break;
                }
            }
        }

        /// <summary>
        /// Метод установки базового значения для соответствующей фичи скилла
        /// </summary>
        /// <typeparam name="T">Тип свойства скилла</typeparam>
        /// <param name="multiplier">Базовое значение</param>
        internal void SetValue<T>(float value) where T : SkillFeature
        {
                for (int i = 0; i < _features.Count; i++)
                {
                    if (_features[i] is T)
                    {
                        _features[i].SetValue(value);
                        break;
                    }
                }
        }

        /// <summary>
        /// Получение значения фичи
        /// </summary>
        /// <typeparam name="T">Тип свойства скилла</typeparam>
        /// <returns></returns>
        internal float GetValue<T>() where T : SkillFeature
        {
            float value = default;
            for (int i = 0; i < _features.Count; i++)
            {
                if (_features[i] is T)
                {
                    value = _features[i].GetValue();
                }
            }
            return value;
        }

        /// <summary>
        /// Метод получения значений свойств скилла
        /// </summary>
        /// <returns>Коллекция значений свойств</returns>
        internal List<float> GetFeaturesValue()
        {
            List<float> values = new List<float>();
            for (int i = 0; i < _features.Count; i++)
            {
                    values.Add(_features[i].GetValue());
            }
            return values;
        }

        /// <summary>
        /// Метод установки значений по-умолчанию
        /// </summary>
        private void LoadDefault()
        {
            SkillFeatures.Add(new DamageFeature(_damageDefault));
            SkillFeatures.Add(new MissProbabilityFeature(_missProbabilityDefault));
            SkillFeatures.Add(new FatigueFeature(_fatigueDefault));
        }      
    }
}