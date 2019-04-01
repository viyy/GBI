using System.Collections.Generic;
using Geekbrains.Skills;
using Geekbrains.Storages;
using Geekbrains.Unit;

namespace Geekbrains
{
    public static class SkillFactory
    {
        private static readonly ISkillStorage Storage = new XmlSkillStorage();

        public static Skill GetSkill(int id, IDummyUnit caster)
        {
            var tmp = Storage.GetSkillInfo(id);
            if (tmp == null) return null;
            var effects = new List<SkillEffectBase>();
            foreach (var effectDto in tmp.Effects) effects.Add(SkillEffectFactory.CreateSkillEffect(effectDto, caster));
            return new Skill(id, tmp.Name, tmp.Range, tmp.Cost, tmp.Flags, effects, tmp.Radius, tmp.Cooldown,
                tmp.RequiredSkills, tmp.CastTime, tmp.Description);
        }
    }
}