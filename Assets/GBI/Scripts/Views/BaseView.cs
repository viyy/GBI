using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Базовый класс представления <br/>
    /// содержит в себе модель и является адаптаром IEventDispatcher
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <see cref="Geekbrains.BaseModel"/><br/>
    /// <see cref="Geekbrains.IEventDispatcher"/><br/>
    /// <see cref="IRegistrator{T}"/>
    public class BaseView<T> : MonoBehaviour, IRegistrator<T>, IEventDispatcher
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

        public void Register(T record)
        {
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