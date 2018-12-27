namespace Geekbrains {
    public class CharacteristicContainerController : BaseController<CharacteristicContainerModel>
    {
        public CharacteristicContainerController(CharacteristicContainerModel characteristicContainerModel) : base(characteristicContainerModel) {}
        
        public CharacteristicController GetSkill(int id)
        {
            return _model[id];
        }
    }
}