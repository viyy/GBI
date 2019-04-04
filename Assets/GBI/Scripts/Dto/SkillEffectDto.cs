using System.Collections.Generic;
using GBI.Utility;

namespace Geekbrains.Skills
{
    public class SkillEffectDto
    {
        /// <summary>
        /// Допустимые типы целей
        /// </summary>
        public TargetModeTypes TargetType { get; set; }
        /// <summary>
        /// Тип эффекта
        /// </summary>
        public SkillEffectTypes EffectType { get; set; }
        /// <summary>
        /// Базовое значение эффекта (урон или исцеление)
        /// </summary>
        public float BaseValue { get; set; }
        
        /// <summary>
        /// зависимости от характеристик
        /// </summary>
        public SerializableDictionary<CharacteristicTypes, float> Values { get; set; } = new SerializableDictionary<CharacteristicTypes, float>();
    }
}