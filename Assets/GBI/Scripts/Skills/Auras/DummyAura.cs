using System.Collections.Generic;
using Geekbrains.Unit;

namespace Geekbrains.Skills.Auras
{
    public class DummyAura : AuraBase
    {
        public DummyAura(int id, AuraTypes type, string name, bool isVisible, bool isPermanent, float duration, Dictionary<CharacteristicTypes, float> values, string icon) : base(id, type, name, isVisible, isPermanent, duration, values, icon)
        {
        }

        public override void Execute(IDummyUnit target)
        {
        }

        public override void Remove(IDummyUnit target)
        {
        }
    }
}