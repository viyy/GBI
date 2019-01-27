namespace Geekbrains
{
    /// <summary>
    /// Интерфейс слушателя событий с возвращением результата
    /// </summary>
    /// <typeparam name="T1">Тип события, наследуемый от BaseEvent</typeparam>
    /// <typeparam name="T2">Тип возвращаемого значения</typeparam>
    public interface IEventListenerWithResult<in T1, out T2> where T1 : BaseEvent
    {
        /// <summary>
        /// Метод, вызываемый при срабатывании события
        /// </summary>
        /// <param name="eventArgs">Параметры события</param>
        /// <typeparam name="T1">Тип события, наследуемый от BaseEvent</typeparam>
        /// <seealso cref="Geekbrains.BaseEvent"/>
        T2 HandleEvent<T1>(T1 eventArgs);
    }
}