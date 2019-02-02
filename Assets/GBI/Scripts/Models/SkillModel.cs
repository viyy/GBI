using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Модель скилла
    /// </summary>
    /// <see cref="BaseModel"/> <br/>
    /// <see cref="IRegistrator{T}"/> <br/>
    /// <see cref="SkillFeature"/>
    public class SkillModel : BaseModel, IRegistrator<SkillFeature>
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

        private SkillModel() { }

        public SkillModel(int id)
        {
            Id        = id;
            _features = new List<SkillFeature>();
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