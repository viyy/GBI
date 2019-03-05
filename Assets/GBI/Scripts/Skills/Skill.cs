using System;
using System.Collections.Generic;
using Geekbrains.Unit;

namespace Geekbrains.Skills
{
    public class Skill : IUpdatable
    {
        public Skill(int id, string name, float range, Dictionary<ResourceTypes, int> cost, SkillFlags flags, List<SkillEffectBase> effects, float radius, float cooldown, List<int> requiredSkills)
        {
            Id = id;
            Name = name;
            Range = range;
            Cost = cost;
            Flags = flags;
            Effects = effects;
            Radius = radius;
            Cooldown = cooldown;
            RequiredSkills = requiredSkills;
            LegalTargets = TargetModeTypes.None;
            foreach (var effect in Effects)
            {
                LegalTargets |= effect.LegalTarget;
            }
        }

        /// <summary>
        /// Id скилла
        /// </summary>
        public int Id { get; private set; }
        
        /// <summary>
        /// List of Skill ids that required to obtain this skill
        /// </summary>
        public List<int> RequiredSkills { get; private set; }
        
        /// <summary>
        /// Название скилла
        /// </summary>
        public string Name { get; private set; }
        
        //TODO: Icon?
        
        /// <summary>
        /// Радиус применения
        /// </summary>
        public float Range { get; private set; }
        
        /// <summary>
        /// Radius of effects if AOE
        /// </summary>
        public float Radius { get; private set; }

        /// <summary>
        /// Time between uses left
        /// </summary>
        public float CurrentCooldown { get; private set; } = 0;
        
        /// <summary>
        /// Max cooldown
        /// </summary>
        public float Cooldown { get; private set; }
        
        /// <summary>
        /// Стоимость навыка
        /// </summary>
        public Dictionary<ResourceTypes, int> Cost { get; private set; }
        
        /// <summary>
        /// Флаги, указывающие на тип и особенности скилла
        /// </summary>
        public SkillFlags Flags { get; private set; }

        public TargetModeTypes LegalTargets { get; private set; }
        /// <summary>
        /// Список эффектов, которые будут применяться к цели
        /// </summary>
        public List<SkillEffectBase> Effects { get; private set; }

        public void Execute(IDummyUnit caster, IEnumerable<IDummyUnit> targets)
        {
            if (Cooldown>0) return;
            foreach (var target in targets)
            {
                foreach (var effect in Effects)
                {
                    if (((effect.LegalTarget & TargetModeTypes.Enemy) > 0) && target.IsEnemyTo(caster) ||
                        ((effect.LegalTarget & TargetModeTypes.Ally) > 0 && target.IsAllyTo(caster)))
                        effect.Execute(caster, target);
                }
            }

            foreach (var effect in Effects)
            {
                if ((effect.LegalTarget & TargetModeTypes.Self)>0)
                    effect.Execute(caster, caster);
            }

            CurrentCooldown = Cooldown;
        }

        public void OnUpdate(float deltaTime)
        {
            if (Cooldown <= 0)
            {
                Cooldown = 0;
                return;
            }
            Cooldown -= deltaTime;
        }
    }
}