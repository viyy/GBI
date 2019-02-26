using System.Collections.Generic;
using Geekbrains.Unit;
using UnityEngine;

namespace Geekbrains.Skills
{
    public class HealEffect : SkillEffectBase
    {
        public HealEffect(Dictionary<CharacteristicTypes, float> values, SkillEffectTypes effectType, float baseValue) : base(values, effectType, baseValue)
        {
        }

        public override void Execute(IDummyUnit caster, IDummyUnit target)
        {
            var dmg = BaseValue;
            foreach (var f in Values)
            {
                if( !caster.TryGetCharacteristic(f.Key, out var tmp)) continue;
                dmg += tmp * f.Value;
            }

            target.Heal(Mathf.FloorToInt(dmg));
        }
    }
}