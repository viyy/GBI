using UnityEngine;

namespace Geekbrains
{
    public class BaseController<T> : IRegistrator<T>, IEventDispatcher
        where T : BaseModel
    {
        protected T _model;

        private EventDispatcher _dispatcher; 

        public BaseController()
        {
            _dispatcher = new EventDispatcher();
        }

        public BaseController(T model) : base()
        {
            Register(model);
        }

        public void Register(T record)
        {
            _model = record;
        }

        public void Unregister(T record)
        {
            Debug.Log("Not supported");
        }

        public void DispatchEvent<E>(E eventArgs)
            where E : BaseEvent
        {
            _dispatcher.DispatchEvent(eventArgs);
        }

        public void AddEventListener<E>(IEventListener<E> listener)
            where E : BaseEvent
        {
            _dispatcher.AddEventListener(listener);
        }
    }
}