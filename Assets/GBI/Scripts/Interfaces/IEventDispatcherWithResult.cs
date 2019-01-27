namespace Geekbrains
{
    /// <summary>
    /// Интерфейс для добавления слушателей с запуска событий для слушателя
    /// </summary>
    public interface IEventDispatcherWithResult
    {
        /// <summary>
        /// Метод запуска события зарегестрированным слушателям, возвращающим результат
        /// </summary>
        /// <typeparam name="T1">Тип события, наследуемый от BaseEvent</typeparam>
        /// <typeparam name="T2">Тип возвращаемого значения</typeparam>
        /// <param name="eventArgs">Объект аргументов события</param>
        /// <returns></returns>
        T2 DispatchEventWithResult<T1, T2>(T1 eventArgs)
            where T1 : BaseEvent;
    }
}