namespace Geekbrains
{
    /// <summary>
    /// Интерфейс для добавления слушателей с запуска событий для слушателя
    /// </summary>
    public interface IEventDispatcher
    {
        /// <summary>
        /// Метод запуска события зарегестрированным слушателям
        /// </summary>
        /// <param name="eventArgs">Объект аргументов события</param>
        /// <typeparam name="T">Тип события, наследуемый от BaseEvent</typeparam>
        /// <seealso cref="Geekbrains.BaseEvent"/>
        void DispatchEvent<T>(T eventArgs)
            where T : BaseEvent;

        /// <summary>
        /// Метод регистрация слушателя событий
        /// </summary>
        /// <param name="listener">Объект слушателя событий</param>
        /// <typeparam name="T">Тип события, имплементирующий IEventListener</typeparam>
        /// <seealso cref="Geekbrains.IEventListener"/>
        void AddEventListener<T>(IEventListener<T> listener)
            where T : BaseEvent;

        /// <summary>
        /// Метод удаления слушателя событий
        /// </summary>
        /// <param name="listener">Объект слушателя событий</param>
        /// <typeparam name="T">Тип события, имплементирующий IEventListener</typeparam>
        /// <seealso cref="Geekbrains.IEventListener"/>
        void RemoveEventListener<T>(IEventListener<T> listener)
            where T : BaseEvent;

        /// <summary>
        /// Метод проверки наличия слушателя событий
        /// </summary>
        /// <param name="listener">Объект слушателя событий</param>
        /// <typeparam name="T">Тип события, имплементирующий IEventListener</typeparam>
        /// <seealso cref="Geekbrains.IEventListener"/>
        bool HasEventListener<T>(IEventListener<T> listener)
            where T : BaseEvent;
    }
}