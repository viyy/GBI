using System.Collections.Generic;
using Geekbrains.Unit;
using UnityEngine;

namespace Geekbrains.Skills
{
    public class DamageEffect : SkillEffectBase
    {
        public DamageEffect(Dictionary<CharacteristicTypes, float> values, SkillEffectTypes effectType, float baseValue,
            TargetModeTypes legalTargets) : base(values, effectType, baseValue, legalTargets)
        {
        }

        public override void Execute(IDummyUnit caster, IDummyUnit target)
        {
            var dmg = BaseValue;
            foreach (var f in Values)
            {
                if (!caster.TryGetCharacteristic(f.Key, out var tmp)) continue;
                dmg += tmp * f.Value;
            }

            target.TakeDamage(Mathf.FloorToInt(dmg), caster);
        }
    }
}