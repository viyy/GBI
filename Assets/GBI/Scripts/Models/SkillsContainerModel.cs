using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Модель хранилища скиллов
    /// </summary>
    /// <see cref="BaseModel"/> <br/>
    /// <see cref="IRegistrator{T}"/> <br/>
    /// <see cref="SkillController"/>
    public class SkillsContainerModel : BaseModel, IRegistrator<SkillController>
    {
        /// <summary>
        /// Хранилище скиллов
        /// </summary>
        /// <see cref="SkillController"/>
        private Dictionary<int, SkillController> _skills;

        public SkillsContainerModel()
        {
            _skills = new Dictionary<int, SkillController>();
        }

        public void Register(SkillController record)
        {
            _skills.Add(record.Id, record);
        }

        public void Unregister(SkillController record)
        {
            if ( _skills.ContainsKey(record.Id) ) {
                _skills.Remove(record.Id);
            }
        }

        /// <summary>
        /// Индексатор для получения скилла по ID
        /// </summary>
        /// <param name="id">ID скилла</param>
        public SkillController this[int id]
        {
            get {
                if ( _skills.ContainsKey(id) ) {
                    return _skills[id];
                }

                return default(SkillController);
            }
        }
    }
}