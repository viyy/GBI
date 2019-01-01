namespace Geekbrains
{
    public class SkillsContainerController : BaseController<SkillsContainerModel>
    {
        public SkillsContainerController(SkillsContainerModel model) : base(model) {}

        public SkillController GetSkill(int id)
        {
            return _model[id];
        }
    }
}