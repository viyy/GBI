namespace Geekbrains
{
    public class BaseModel : IEventDispatcher
    {
        private EventDispatcher _dispatcher;
        
        public BaseModel()
        {
            _dispatcher = new EventDispatcher();
        }

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