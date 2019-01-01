using System.Collections.Generic;

namespace Geekbrains
{
    public class SkillModel : BaseModel, IRegistrator<SkillFeature>
    {
        public int Id { get; private set; }

        private List<SkillFeature> _features;

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