using System.Collections.Generic;
using Geekbrains.Skills;

namespace Geekbrains.Storages
{
    public class XmlSkillStorage : ISkillStorage
    {
        private const int Capacity = 100;
        private static Dictionary<int, SkillDto> _cache = new Dictionary<int, SkillDto>(Capacity);
        public SkillDto GetSkillInfo(int id)
        {
            if (_cache.ContainsKey(id)) return _cache[id];
            //TODO: Read from xml
            return null;
        }
    }
}