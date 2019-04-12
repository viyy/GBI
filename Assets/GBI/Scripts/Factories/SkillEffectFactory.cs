using System;
using System.Collections.Generic;
using Geekbrains.Skills;
using Geekbrains.Unit;

namespace Geekbrains
{
    public static class SkillEffectFactory
    {
        public static SkillEffectBase CreateSkillEffect(SkillEffectDto dto, IDummyUnit caster)
        {
            SkillEffectBase skill = null;
            switch (dto.EffectType)
            {
                case SkillEffectTypes.Damage:
                    skill = new DamageEffect(dto.Values, SkillEffectTypes.Damage, dto.BaseValue,dto.TargetType);
                    break;
                case SkillEffectTypes.Heal:
                    skill = new HealEffect(dto.Values, SkillEffectTypes.Damage, dto.BaseValue,dto.TargetType);
                    break;
                case SkillEffectTypes.Vampirism:
                    skill = new VampirismEffect(dto.Values, SkillEffectTypes.Damage, dto.BaseValue,dto.TargetType);
                    break;
                case SkillEffectTypes.Aura:
                    var a = AuraFactory.GetAura((int) dto.BaseValue, caster);
                    skill = new AuraEffect(dto.Values, SkillEffectTypes.Aura, dto.BaseValue, dto.TargetType, a);
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