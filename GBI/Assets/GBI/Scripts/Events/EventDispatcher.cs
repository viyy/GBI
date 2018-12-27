using System;
using System.Collections.Generic;

namespace Geekbrains
{
    public class EventDispatcher : IEventDispatcher
    {
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