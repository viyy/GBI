using System.Collections.Generic;
using Geekbrains.Unit;

namespace Geekbrains.Skills
{
    public class Skill
    {
        public Skill(int id, string name, float range, Dictionary<ResourceTypes, int> cost, SkillFlags flags, List<SkillEffect> effects)
        {
            Id = id;
            Name = name;
            Range = range;
            Cost = cost;
            Flags = flags;
            Effects = effects;
        }

        /// <summary>
        /// Id скилла
        /// </summary>
        public int Id { get; private set; }
        
        /// <summary>
        /// Название скилла
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Радиус применения
        /// </summary>
        public float Range { get; private set; }
        
        /// <summary>
        /// Стоимость навыка
        /// </summary>
        public Dictionary<ResourceTypes, int> Cost { get; private set; }
        
        /// <summary>
        /// Флаги, указывающие на тип и особенности скилла
        /// </summary>
        public SkillFlags Flags { get; private set; }
        
        /// <summary>
        /// Список эффектов, которые будут применяться к цели
        /// </summary>
        public List<SkillEffect> Effects { get; private set; }

        public void Execute(IUnit caster, IEnumerable<IUnit> targets)
        {
            foreach (var target in targets)
            {
                foreach (var effect in Effects)
                {
                    effect.Execute(caster, target);
                }
            }
        }
    }
}