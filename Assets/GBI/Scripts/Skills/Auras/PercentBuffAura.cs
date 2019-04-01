using System.Collections.Generic;
using Geekbrains.Unit;

namespace Geekbrains.Skills.Auras
{
    public class PercentBuffAura : AuraBase
    {
        public PercentBuffAura(int id, AuraTypes type, string name, bool isVisible, bool isPermanent, float duration,
            Dictionary<CharacteristicTypes, float> values, string icon) : base(id, type, name, isVisible, isPermanent,
            duration, values, icon)
        {
        }


        public override void Execute(IDummyUnit target)
        {
            foreach (var f in Values) target.AddCharacteristicPercent(f.Key, f.Value);
        }

        public override void Remove(IDummyUnit target)
        {
            foreach (var f in Values) target.AddCharacteristicPercent(f.Key, -f.Value);
        }
    }
}