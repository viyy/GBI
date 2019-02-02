namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера для скилла
    /// </summary>
    /// <see cref="BaseController{T}"/> <br/>
    /// <see cref="IRegistrator{T}"/> <br/>
    /// <see cref="IRegistrator{T}"/>
    public class SkillController : BaseController<SkillModel>, IRegistrator<SkillFeature>
    {
        public int CurrentLevel { get; protected set; } = 1;

        public bool IsDamage { get; protected set; } = false;

        public bool IsFatigue { get; protected set; } = false;

        public bool IsMissProbability { get; protected set; } = false;

        public int Id => _model.Id;

        public void Register(SkillFeature record)
        {
            _model.Register(record);
        }

        public void Unregister(SkillFeature record)
        {
            _model.Unregister(record);
        }
    }
}