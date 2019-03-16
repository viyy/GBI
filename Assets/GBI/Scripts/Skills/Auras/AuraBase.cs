using System.Collections.Generic;
using Geekbrains.Unit;

namespace Geekbrains.Skills.Auras
{
    public abstract class AuraBase : IUpdatable
    {
        protected Dictionary<CharacteristicTypes, float> Values;

        protected AuraBase(int id, AuraTypes type, string name, bool isVisible, bool isPermanent, float duration,
            Dictionary<CharacteristicTypes, float> values, string icon)
        {
            Type = type;
            Name = name;
            IsVisible = isVisible;
            IsPermanent = isPermanent;
            Duration = duration;
            Values = values;
            Icon = icon;
            Id = id;
        }

        public int Id { get; protected set; }
        public AuraTypes Type { get; protected set; }
        public string Name { get; protected set; }
        public bool IsVisible { get; protected set; }
        public bool IsPermanent { get; protected set; }
        public float Duration { get; protected set; }

        public string Icon { get; protected set; }

        public IDummyUnit Caster { get; protected set; }

        public virtual void OnUpdate(float deltaTime)
        {
            Duration -= deltaTime;
        }

        public void SetCaster(IDummyUnit caster)
        {
            Caster = caster;
        }

        public abstract void Execute(IDummyUnit target);

        public abstract void Remove(IDummyUnit target);
    }
}