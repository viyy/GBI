using System.Collections.Generic;

namespace Geekbrains.Skills
{
    public class SkillEffectDto
    {
        public TargetModeTypes TargetType { get; set; }
        public SkillEffectTypes EffectType { get; set; }
        public float BaseValue { get; set; }
        public Dictionary<CharacteristicTypes, float> Values { get; set; }
    }
}