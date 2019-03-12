using System.Collections.Generic;
using Geekbrains.Unit;
using UnityEngine;

namespace Geekbrains.Skills.Auras
{
    public class FlatBuffAura : AuraBase
    {
        

        public override void Execute(IDummyUnit target)
        {
            foreach (var f in Values)
            {
                target.AddToCharacteristic(f.Key, Mathf.FloorToInt(f.Value));
            }
        }

        public override void Remove(IDummyUnit target)
        {
            foreach (var f in Values)
            {
                target.AddToCharacteristic(f.Key, -Mathf.FloorToInt(f.Value));
            }
        }

        public FlatBuffAura(int id, AuraTypes type, string name, bool isVisible, bool isPermanent, float duration, Dictionary<CharacteristicTypes, float> values, string icon) : base(id, type, name, isVisible, isPermanent, duration, values, icon)
        {
        }
    }
}