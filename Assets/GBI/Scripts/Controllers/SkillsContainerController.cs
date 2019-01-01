namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера хранилища скиллов
    /// </summary>
    /// <see cref="BaseController{T}"/> <br/>
    /// <see cref="SkillsContainerModel"/>
    public class SkillsContainerController : BaseController<SkillsContainerModel>
    {
        public SkillsContainerController(SkillsContainerModel model) : base(model) {}

        /// <summary>
        /// Метод получения скилла по его Id
        /// </summary>
        /// <param name="id">Id скилла</param>
        /// <returns>Контроллер скилла</returns>
        /// <see cref="SkillController"/>
        public SkillController GetSkill(int id)
        {
            return _model[id];
        }
    }
}