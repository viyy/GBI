namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера характеристики персонажа 
    /// </summary>
    /// <see cref="IRegistrator{T}"/> <br/>
    /// <see cref="BaseController{T}"/> <br/>
    /// <see cref="CharacteristicModel"/>
    public class CharacteristicController : BaseController<CharacteristicModel>, IRegistrator<CharacteristicFeature>
    {
        /// <summary>
        /// Id характеристики
        /// </summary>
        public int Id => _model.Id;

        public CharacteristicController(CharacteristicModel characteristicModel) : base(characteristicModel) { }

        /// <summary>
        /// Метод делегирующий регистрацию черты характера
        /// </summary>
        /// <param name="record">Черта характера</param>
        /// <see cref="CharacteristicFeature"/>
        public void Register(CharacteristicFeature record)
        {
            _model.Register(record);
        }

        /// <summary>
        /// Метод делегирующий удаления черты характера
        /// </summary>
        /// <param name="record">Черта характера</param>
        /// <see cref="CharacteristicFeature"/>
        public void Unregister(CharacteristicFeature record)
        {
            _model.Unregister(record);
        }
    }
}