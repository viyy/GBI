using System;
using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Класс события применения "Мощной атаки"
    /// </summary>
    internal sealed class PowerfulAttackExecutedEvent : BaseEvent
    {
        /// <summary>
        /// Свойство, хронящее значения свойств "Мощной атаки"
        /// </summary>
        internal List<float> FeatureValues { get; private set; }   

        /// <summary>
        /// Метод вызова события применения "Мощной атаки"
        /// </summary>
        /// <param name="values">Коллекция значений свойств скилла "Мощная атака"</param>
        internal PowerfulAttackExecutedEvent(List<float> values)
        {
            FeatureValues = values;
        }
    }
}
