using System.Collections.Generic;

namespace Geekbrains.Skills
{
    public class SkillEffectDto
    {
        public int EffectType { get; set; }
        public float BaseValue { get; set; }
        public Dictionary<int, float> Values { get; set; }
    }
}