using System.Collections.Generic;
using GBI.Utility;

namespace Geekbrains.Skills
{
    public class SkillEffectDto
    {
        public TargetModeTypes TargetType { get; set; }
        public SkillEffectTypes EffectType { get; set; }
        public float BaseValue { get; set; }
        public SerializableDictionary<CharacteristicTypes, float> Values { get; set; } = new SerializableDictionary<CharacteristicTypes, float>();
    }
}