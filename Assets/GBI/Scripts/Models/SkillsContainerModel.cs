using System.Collections.Generic;

namespace Geekbrains
{
    public class SkillsContainerModel : BaseModel, IRegistrator<SkillController>
    {
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