namespace Geekbrains
{
    /// <summary>
    /// Базовый класс модели <br/>
    /// является адаптаром IEventDispatcher
    /// </summary>
    /// <see cref="Geekbrains.IEventDispatcher"/>
    public class BaseModel : IEventDispatcher
    {
        /// <summary>
        /// Объект диспатчера
        /// </summary>
        private readonly EventDispatcher _dispatcher = new EventDispatcher();
        
        public void DispatchEvent<T>(T eventArgs)
            where T : BaseEvent
        {
            _dispatcher.DispatchEvent(eventArgs);
        }

        public void AddEventListener<T>(IEventListener<T> listener)
            where T : BaseEvent
        {
            _dispatcher.AddEventListener(listener);
        }
    }
}