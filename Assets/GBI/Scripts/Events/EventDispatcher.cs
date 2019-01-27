using System;
using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Класс для добавления слушателей с запуска событий для слушателя
    /// </summary>
    /// <see cref="IEventDispatcher"/>
    public class EventDispatcher : IEventDispatcher
    {
        /// <summary>
        /// Список объектов-слушателей событий
        /// </summary>
        private List<object> _eventListeners;

        public EventDispatcher()
        {
            _eventListeners = new List<object>();
        }

        public void DispatchEvent<T>(T eventArgs)
            where T : BaseEvent
        {
            for ( var i = 0; i < _eventListeners.Count; i++ ) {
                var eventListener = _eventListeners[i] as IEventListener<T>;
                eventListener?.HandleEvent(eventArgs);
            }
        }

        public T2 DispatchEventWithResult<T1,T2>(T1 eventArgs)
            where T1 : BaseEvent
        {
            IEventListenerWithResult<T1, T2> eventListener = null;
            for (var i = 0; i < _eventListeners.Count; i++)
            {
                if (_eventListeners[i] is IEventListenerWithResult<T1, T2>)
                    eventListener = _eventListeners[i] as IEventListenerWithResult<T1, T2>;
            }
            if (eventListener != null)
                return (eventListener as IEventListenerWithResult<T1, T2>).HandleEvent(eventArgs);
            else
                return default(T2);
        }

        public void AddEventListener<T>(IEventListener<T> listener)
            where T : BaseEvent
        {
            _eventListeners.Add(listener);
        }

        public void RemoveEventListener<T>(IEventListener<T> listener)
            where T : BaseEvent
        {
            if ( _eventListeners.Contains(listener) ) {
                _eventListeners.Remove(listener);
            }
        }

        public bool HasEventListener<T>(IEventListener<T> listener)
            where T : BaseEvent
        {
            return _eventListeners.Contains(listener);
        }
    }
}