using System.Collections.Generic;
using Geekbrains.Unit;

namespace Geekbrains.Skills
{
    public class Skill : BaseModel, IUpdatable
    {
        public Skill(int id, string name, float range, Dictionary<ResourceTypes, int> cost, SkillFlags flags,
            List<SkillEffectBase> effects, float radius, float cooldown, List<int> requiredSkills, float castTime,
            string description)
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
            CastTime = castTime;
            Description = description;
            LegalTargets = TargetModeTypes.None;
            foreach (var effect in Effects) LegalTargets |= effect.LegalTarget;
        }

        /// <summary>
        ///     Id скилла
        /// </summary>
        public int Id { get; }

        /// <summary>
        ///     List of Skill ids that required to obtain this skill
        /// </summary>
        public List<int> RequiredSkills { get; }

        /// <summary>
        ///     Название скилла
        /// </summary>
        public string Name { get; }

        //TODO: Icon?

        /// <summary>
        ///     Радиус применения
        /// </summary>
        public float Range { get; }

        /// <summary>
        ///     Radius of effects if AOE
        /// </summary>
        public float Radius { get; }

        /// <summary>
        ///     Time between uses left
        /// </summary>
        public float CurrentCooldown { get; private set; }

        /// <summary>
        ///     Max cooldown
        /// </summary>
        public float Cooldown { get; private set; }

        /// <summary>
        ///     Time, required to use this skill
        /// </summary>
        public float CastTime { get; }

        //TODO: Speed of particles?

        /// <summary>
        ///     Стоимость навыка
        /// </summary>
        public Dictionary<ResourceTypes, int> Cost { get; }

        /// <summary>
        ///     Флаги, указывающие на тип и особенности скилла
        /// </summary>
        public SkillFlags Flags { get; }

        public TargetModeTypes LegalTargets { get; }

        /// <summary>
        ///     Список эффектов, которые будут применяться к цели
        /// </summary>
        public List<SkillEffectBase> Effects { get; }

        /// <summary>
        ///     Описание скилла для пользователя
        /// </summary>
        public string Description { get; }

        public void OnUpdate(float deltaTime)
        {
            if (Cooldown <= 0)
            {
                Cooldown = 0;
                return;
            }

            Cooldown -= deltaTime;
        }

        public void Execute(IDummyUnit caster, IEnumerable<IDummyUnit> targets)
        {
            if (Cooldown > 0) return;
            foreach (var target in targets)
            foreach (var effect in Effects)
                if ((effect.LegalTarget & TargetModeTypes.Enemy) > 0 && target.IsEnemyTo(caster) ||
                    (effect.LegalTarget & TargetModeTypes.Ally) > 0 && target.IsAllyTo(caster))
                    effect.Execute(caster, target);

            foreach (var effect in Effects)
                if ((effect.LegalTarget & TargetModeTypes.Self) > 0)
                    effect.Execute(caster, caster);

            CurrentCooldown = Cooldown;
        }

        public bool CanBeCasted(IDummyUnit caster, IDummyUnit target)
        {
            if (!caster.IsAbleToUseSkills) return false;
            foreach (var i in Cost)
            {
                if (!caster.CurrentResources.ContainsKey(i.Key)) return false;
                {
                    if (caster.CurrentResources[i.Key] < i.Value) return false;
                }
            }

            if (target == null) return true;
            if (caster.DistanceTo(target) > Range) return false;
            return (caster.GetTargetModeTypesFor(target) & LegalTargets) != 0;
        }
    }
}