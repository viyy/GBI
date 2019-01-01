using System.Collections.Generic;

namespace Geekbrains {
    public class CharacteristicModel : BaseModel, IRegistrator<CharacteristicFeature>
    {
        public int Id { get; private set; }

        private List<CharacteristicFeature> _features;

        public CharacteristicModel(int id)
        {
            Id        = id;
            _features = new List<CharacteristicFeature>();
        }

        public void Register(CharacteristicFeature record)
        {
            _features.Add(record);
        }

        public void Unregister(CharacteristicFeature record)
        {
            if ( _features.Contains(record) ) {
                _features.Remove(record);
            }
        }
    }
}