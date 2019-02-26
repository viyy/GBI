using Geekbrains.Skills;

namespace Geekbrains
{
    public interface ISkillStorage
    {
        SkillDto GetSkillInfo(int id);
    }
}