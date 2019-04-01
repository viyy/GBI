using System.Collections.Generic;
using GBI.Utility;

namespace Geekbrains.Skills
{
    public class SkillDto
    {
        public int Id { get; set; }

        /// <summary>
        ///     List of Skill ids that required to obtain this skill
        /// </summary>
        public List<int> RequiredSkills { get; set; } = new List<int>();

        /// <summary>
        ///     Название скилла
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Радиус применения
        /// </summary>
        public float Range { get; set; }

        public float Radius { get; set; }

        public float Cooldown { get; set; }

        /// <summary>
        ///     Стоимость навыка
        /// </summary>
        public SerializableDictionary<ResourceTypes, int> Cost { get; set; } = new SerializableDictionary<ResourceTypes, int>();

        /// <summary>
        ///     Флаги, указывающие на тип и особенности скилла
        /// </summary>
        public SkillFlags Flags { get; set; }

        /// <summary>
        ///     Список эффектов, которые будут применяться к цели
        /// </summary>
        public List<SkillEffectDto> Effects { get; set; } = new List<SkillEffectDto>();

        public float CastTime { get; set; }

        public string Description { get; set; }
    }
}