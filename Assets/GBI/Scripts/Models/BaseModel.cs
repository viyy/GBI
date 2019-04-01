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
        protected readonly EventDispatcher _dispatcher = new EventDispatcher();
        
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

        public void RemoveEventListener<T>(IEventListener<T> listener)
            where T : BaseEvent
        {
            _dispatcher.RemoveEventListener(listener);
        }

        public bool HasEventListener<T>(IEventListener<T> listener)
            where T : BaseEvent
        {
            return _dispatcher.HasEventListener(listener);
        }
    }
}