using System.Collections.Generic;
using Geekbrains.Unit;
using UnityEngine;

namespace Geekbrains.Skills.Auras
{
    public class DoTAura : AuraBase
    {
        public DoTAura(int id, AuraTypes type, string name, bool isVisible, bool isPermanent, float duration,
            Dictionary<CharacteristicTypes, float> values, string icon) : base(id, type, name, isVisible, isPermanent,
            duration, values, icon)
        {
        }

        public override void Execute(IDummyUnit target)
        {
            var dmg = 0f;
            foreach (var value in Values)
            {
                if (!Caster.TryGetCharacteristic(value.Key, out var tmp)) continue;
                dmg += tmp * value.Value;
            }

            target.TakeDamage(Mathf.FloorToInt(dmg));
        }

        public override void Remove(IDummyUnit target)
        {
            //Nothing to do here
        }
    }
}