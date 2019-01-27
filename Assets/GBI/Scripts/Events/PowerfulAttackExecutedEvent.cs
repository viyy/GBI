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
        /// Событие применения "Мощной атаки"
        /// </summary>
        internal event Action<List<float>> OnPowerfulAttackExecutedEvent;

        /// <summary>
        /// Метод вызова события применения "Мощной атаки"
        /// </summary>
        /// <param name="values">Коллекция значений свойств скилла "Мощная атака"</param>
        internal void Invoke(List<float> values)
        {
            OnPowerfulAttackExecutedEvent.Invoke(values);
        }
    }
}
