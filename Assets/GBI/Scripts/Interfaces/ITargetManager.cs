using System.Collections.Generic;
using System.Threading.Tasks;
using Geekbrains.Skills;
using Geekbrains.Unit;

namespace Geekbrains
{
    public interface ITargetManager
    {
        Task<List<IDummyUnit>> GetTargets(IDummyUnit caster, Skill skill); 
    }
}