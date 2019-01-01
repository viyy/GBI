using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Модель хранилища характеристики персонажа
    /// </summary>
    /// <see cref="BaseModel"/> <br/>
    /// <see cref="IRegistrator{T}"/> <br/>
    /// <see cref="CharacteristicController"/>
    public class CharacteristicContainerModel : BaseModel, IRegistrator<CharacteristicController>
    {
        /// <summary>
        /// Словарь для хранения Характеристик
        /// </summary>
        private Dictionary<int, CharacteristicController> _characteristics;

        public CharacteristicContainerModel()
        {
            _characteristics = new Dictionary<int, CharacteristicController>();
        }

        public void Register(CharacteristicController record)
        {
            _characteristics.Add(record.Id, record);
        }

        public void Unregister(CharacteristicController record)
        {
            if ( _characteristics.ContainsKey(record.Id) ) {
                _characteristics.Remove(record.Id);
            }
        }

        /// <summary>
        /// Индексатор, для получения характеристики по Id
        /// </summary>
        /// <param name="id">Id характеристики</param>
        public CharacteristicController this[int id]
        {
            get
            {
                if ( _characteristics.ContainsKey(id) ) {
                    return _characteristics[id];
                }

                return default(CharacteristicController);
            }
        }
    }
}