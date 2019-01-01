namespace Geekbrains
{
    /// <summary>
    /// Класс хранилища характеристик персонажа
    /// </summary>
    /// <see cref="BaseController{T}"/> <br/>
    /// <see cref="CharacteristicContainerModel"/>
    public class CharacteristicContainerController : BaseController<CharacteristicContainerModel>
    {
        public CharacteristicContainerController(CharacteristicContainerModel characteristicContainerModel) :
            base(characteristicContainerModel) { }

        /// <summary>
        /// Метод получения характеристики персонажа
        /// </summary>
        /// <param name="id">Id характеристики персонажа</param>
        /// <returns>Объект контроллера характеристики персонажа</returns>
        /// <see cref="CharacteristicController"/>
        public CharacteristicController GetCharacteristic(int id)
        {
            return _model[id];
        }
    }
}