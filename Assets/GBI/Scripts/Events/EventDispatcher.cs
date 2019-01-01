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
            _eventListeners.ForEach(listener => {
                                        var eventListener = listener as IEventListener<T>;
                                        eventListener?.HandleEvent(eventArgs);
                                    }
                                   );
        }

        public void AddEventListener<T>(IEventListener<T> listener)
            where T : BaseEvent
        {
            _eventListeners.Add(listener);
        }
    }
}