using System.Collections.Generic;
using Geekbrains.Unit;

namespace Geekbrains.Skills
{
    public abstract class SkillEffect
    {
        private Dictionary<string, float> _values = new Dictionary<string, float>();

        protected SkillEffect(Dictionary<string, float> values)
        {
            _values = values;
        }

        public abstract void Execute(IUnit caster, IUnit target);
    }
}