using System;
using System.Collections.Generic;
using Geekbrains.Skills;
using Geekbrains.Storages;
using Geekbrains.Unit;

namespace Geekbrains
{
    public static class SkillEffectFactory
    {
        public static SkillEffectBase CreateSkillEffect(SkillEffectDto dto, IDummyUnit caster)
        {
            SkillEffectBase skill = null;
            var values = new Dictionary<CharacteristicTypes, float>();
            foreach (var f in dto.Values)
            {
                values.Add((CharacteristicTypes)f.Key, f.Value);
            }
            switch ((SkillEffectTypes)dto.EffectType)
            {
                case SkillEffectTypes.Damage:
                    skill = new DamageEffect(values, SkillEffectTypes.Damage, dto.BaseValue,(TargetModeTypes)dto.TargetType);
                    break;
                case SkillEffectTypes.Heal:
                    skill = new HealEffect(values, SkillEffectTypes.Damage, dto.BaseValue,(TargetModeTypes)dto.TargetType);
                    break;
                case SkillEffectTypes.Vampirism:
                    skill = new VampirismEffect(values, SkillEffectTypes.Damage, dto.BaseValue,(TargetModeTypes)dto.TargetType);
                    break;
                case SkillEffectTypes.Aura:
                    var a = AuraFactory.GetAura((int) dto.BaseValue, caster);
                    
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            //TODO: Custom exception
            if (skill==null) throw new Exception("Can't create skill effect");
            return skill;
        }
    }
}