using System.Collections.Generic;

namespace Geekbrains {
    /// <summary>
    /// Модель характеристики персонажа
    /// </summary>
    /// <see cref="BaseModel"/><br/>
    /// <see cref="IRegistrator{T}"/><br/>
    /// <see cref="CharacteristicFeature"/>
    public class CharacteristicModel : BaseModel, IRegistrator<CharacteristicFeature>
    {
        /// <summary>
        /// ID характеристики
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Список черт характеристики
        /// </summary>
        /// <see cref="CharacteristicFeature"/>
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