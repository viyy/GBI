namespace Geekbrains
{
    /// <summary>
    /// Интерфейс слушателя событий
    /// </summary>
    /// <typeparam name="T">Тип события, наследуемый от BaseEvent</typeparam>
    public interface IEventListener<in T> where T : BaseEvent
    {
        /// <summary>
        /// Метод, вызываемый при срабатывании события
        /// </summary>
        /// <param name="eventArgs">Параметры события</param>
        /// <typeparam name="T">Тип события, наследуемый от BaseEvent</typeparam>
        /// <seealso cref="Geekbrains.BaseEvent"/>
        void HandleEvent(T eventArgs);
    }
}