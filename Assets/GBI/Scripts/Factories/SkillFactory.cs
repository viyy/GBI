using System.Collections.Generic;
using Geekbrains.Skills;
using Geekbrains.Storages;

namespace Geekbrains
{
    public static class SkillFactory
    {
        private static readonly ISkillStorage Storage = new XmlSkillStorage();
        public static Skill GetSkill(int id)
        {
            var tmp = Storage.GetSkillInfo(id);
            if (tmp == null) return null;
            var cost = new Dictionary<ResourceTypes, int>();
            foreach (var i in tmp.Cost)
            {
                cost.Add((ResourceTypes)i.Key,i.Value);
            }
            var effects = new List<SkillEffectBase>();
            foreach (var effectDto in tmp.Effects)
            {
                effects.Add(SkillEffectFactory.CreateSkillEffect(effectDto));
            }
            return new Skill(id, tmp.Name, tmp.Range, cost, (SkillFlags)tmp.Flags, effects, tmp.Radius, tmp.Cooldown, tmp.RequiredSkills);
        }
    }
}