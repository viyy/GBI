using System.Collections.Generic;
using Geekbrains.Unit;

namespace Geekbrains.Skills
{
    public abstract class SkillEffectBase
    {
        public TargetModeTypes LegalTarget { get; }
        public SkillEffectTypes EffectType { get; }
        public float BaseValue { get; }
        protected Dictionary<CharacteristicTypes, float> Values;

        protected SkillEffectBase(Dictionary<CharacteristicTypes, float> values, SkillEffectTypes effectType, float baseValue, TargetModeTypes legalTarget)
        {
            Values = values;
            EffectType = effectType;
            BaseValue = baseValue;
            LegalTarget = legalTarget;
        }

        public abstract void Execute(IDummyUnit caster, IDummyUnit target);
    }
}