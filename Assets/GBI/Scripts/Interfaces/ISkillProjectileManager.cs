using System.Collections.Generic;
using Geekbrains.Skills;
using Geekbrains.Unit;

namespace Geekbrains
{
    /// <summary>
    ///     Реализация отвечает за запуск снарядов и анимаций, связанных со скиллом.
    /// </summary>
    public interface ISkillProjectileManager
    {
        void LaunchSkill(Skill skill, IDummyUnit caster, List<IDummyUnit> targets);
    }
}