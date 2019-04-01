using Geekbrains.Skills;

namespace Geekbrains
{
    public interface ISkillSaver
    {
        void SaveSkill(SkillDto dto);
        int GetNewId();
    }
}