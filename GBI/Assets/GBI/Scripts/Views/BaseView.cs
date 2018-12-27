using UnityEngine;

namespace Geekbrains
{
    public class BaseView<T> : MonoBehaviour, IRegistrator<T>, IEventDispatcher
        where T : BaseModel
    {
        protected T _model;

        private EventDispatcher _dispatcher;

        public void Register(T record)
        {
            _dispatcher = new EventDispatcher();
            _model      = record;
        }

        public void Unregister(T record)
        {
            Debug.Log("Not supported");
        }

        public void DispatchEvent<T1>(T1 eventArgs)
            where T1 : BaseEvent
        {
            _dispatcher?.DispatchEvent(eventArgs);
        }

        public void AddEventListener<T1>(IEventListener<T1> listener)
            where T1 : BaseEvent
        {
            _dispatcher?.AddEventListener(listener);
        }
    }
}