using Geekbrains.Skills;

namespace Geekbrains
{
    public interface IDevSkillSaver
    {
        void SaveSkill(SkillDto dto);
        int GetNextId();
    }
}