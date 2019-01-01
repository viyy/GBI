namespace Geekbrains {
    public class CharacteristicController : BaseController<CharacteristicModel>, IRegistrator<CharacteristicFeature>
    {
        public int Id => _model.Id;
        
        public CharacteristicController(CharacteristicModel characteristicModel) : base(characteristicModel){}
        
        public void Register(CharacteristicFeature record)
        {
            _model.Register(record);
        }

        public void Unregister(CharacteristicFeature record)
        {
            _model.Unregister(record);
        }
    }
}