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
            return new Skill(id, tmp.Name, tmp.Range, cost, (SkillFlags)tmp.Flags, new List<SkillEffect>());
        }
    }
}