using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Модель скилла
    /// </summary>
    /// <see cref="BaseModel"/> <br/>
    /// <see cref="IRegistrator{T}"/> <br/>
    /// <see cref="SkillFeature"/>
    public class SkillModel : BaseModel, IRegistrator<SkillFeature>, IEventDispatcherWithResult
    {
        /// <summary>
        /// ID скилла
        /// </summary>
        public int Id { get;}

        /// <summary>
        /// Список свойств скилла
        /// </summary>
        /// <see cref="SkillFeature"/>
        protected List<SkillFeature> _features;

        public SkillModel(int id)
        {
            Id        = id;
            _features = new List<SkillFeature>();
        }

        public T2 DispatchEventWithResult<T1, T2>(T1 eventArgs)
            where T1 : BaseEvent
        {
            return _dispatcher.DispatchEventWithResult<T1, T2>(eventArgs);
        }

        public void Register(SkillFeature record)
        {
            _features.Add(record);
        }

        public void Unregister(SkillFeature record)
        {
            if ( _features.Contains(record) ) {
                _features.Remove(record);
            }
        }
    }
}