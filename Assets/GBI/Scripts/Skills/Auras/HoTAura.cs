using System.Collections.Generic;
using Geekbrains.Unit;
using UnityEngine;

namespace Geekbrains.Skills.Auras
{
    public class HoTAura : AuraBase
    {
        public HoTAura(int id, AuraTypes type, string name, bool isVisible, bool isPermanent, float duration,
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

            target.Heal(Mathf.FloorToInt(dmg));
        }

        public override void Remove(IDummyUnit target)
        {
            //nothing to do here
        }
    }
}