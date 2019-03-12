using System.Collections.Generic;
using Geekbrains.Skills.Auras;
using Geekbrains.Unit;

namespace Geekbrains.Skills
{
    public class AuraEffect : SkillEffectBase
    {
        private readonly AuraBase _aura;
        public AuraEffect(Dictionary<CharacteristicTypes, float> values, SkillEffectTypes effectType, float baseValue, TargetModeTypes legalTarget, AuraBase aura) : base(values, effectType, baseValue, legalTarget)
        {
            _aura = aura;
        }

        public override void Execute(IDummyUnit caster, IDummyUnit target)
        {
            target.ApplyAura(_aura);
        }
    }
}