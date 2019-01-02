using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Базовый класс контроллера <br/>
    /// содержит в себе модель и является адаптаром IEventDispatcher
    /// </summary>
    /// <typeparam name="T">Класс модели, наследуемого от BaseModel</typeparam>
    /// <see cref="Geekbrains.BaseModel"/><br/>
    /// <see cref="Geekbrains.IEventDispatcher"/><br/>
    /// <see cref="IRegistrator{T}"/>
    public class BaseController<T> : IRegistrator<T>, IEventDispatcher
        where T : BaseModel
    {
        /// <summary>
        /// Объект модели <br/>
        /// Может быть null
        /// </summary>
        protected T _model;

        /// <summary>
        /// Объект диспатчера
        /// </summary>
        private readonly EventDispatcher _dispatcher = new EventDispatcher();

        public BaseController() { }

        public BaseController(T model)
        {
            Register(model);
        }

        public void Register(T record)
        {
            _model = record;
        }

        public void Unregister(T record)
        {
            LogWrapper.Error("Not supported");
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