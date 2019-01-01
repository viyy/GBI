using System.Collections.Generic;

namespace Geekbrains {
    public class CharacteristicContainerModel : BaseModel
    {
        private Dictionary<int, CharacteristicController> _skills;

        public CharacteristicContainerModel()
        {
            _skills = new Dictionary<int, CharacteristicController>();
        }

        public void Register(CharacteristicController record)
        {
            _skills.Add(record.Id, record);
        }

        public void Unregister(SkillController record)
        {
            if ( _skills.ContainsKey(record.Id) ) {
                _skills.Remove(record.Id);
            }
        }

        public CharacteristicController this[int id]
        {
            get {
                if ( _skills.ContainsKey(id) ) {
                    return _skills[id];
                }

                return default(CharacteristicController);
            }
        }
    }
}