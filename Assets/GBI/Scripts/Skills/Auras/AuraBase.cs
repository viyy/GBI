using System.Collections.Generic;
using Geekbrains.Unit;

namespace Geekbrains.Skills.Auras
{
    public abstract class AuraBase : IUpdatable
    {
        public AuraTypes Type { get; protected set; }
        public string Name { get; protected set; }
        public bool IsVisible { get; protected set; }
        public bool IsPermanent { get; protected set; }
        public float Duration { get; protected set; }

        protected Dictionary<string, float> Values;

        protected AuraBase(AuraTypes type, string name, bool isVisible, bool isPermanent, float duration, Dictionary<string, float> values)
        {
            Type = type;
            Name = name;
            IsVisible = isVisible;
            IsPermanent = isPermanent;
            Duration = duration;
            Values = values;
        }

        //TODO: Icon?
        public virtual void OnUpdate(float deltaTime)
        {
            Duration -= deltaTime;
        }

        public abstract void Execute(IDummyUnit target);
    }
}