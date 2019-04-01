using System.Collections.Generic;
using System.Threading.Tasks;
using Geekbrains.Skills;
using Geekbrains.Unit;

namespace Geekbrains
{
    /// <summary>
    ///     Интерфейс для управления целями (выбор зоны, определение попавших под удар)
    /// </summary>
    public interface ITargetManager
    {
        Task<List<IDummyUnit>> GetTargets(IDummyUnit caster, Skill skill);
        List<IDummyUnit> VerifyTargets(IDummyUnit caster, Skill skill, List<IDummyUnit> initialTargets);
    }
}