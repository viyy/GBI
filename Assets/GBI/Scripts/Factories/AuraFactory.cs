using System;
using System.Collections.Generic;
using GBI.Scripts.Storage;
using Geekbrains.Skills.Auras;
using Geekbrains.Unit;

namespace Geekbrains
{
    public class AuraFactory
    {
        private static IAuraStorage _storage = new XmlAuraStorage();

        public static AuraBase GetAura(int id, IDummyUnit caster)
        {
            var tmp = _storage.GetAuraInfo(id);
            AuraBase aura = null;
            switch (tmp.Type)
            {
                case AuraTypes.DoT:
                    aura = new DoTAura(tmp.Id, AuraTypes.DoT, tmp.Name, tmp.IsVisible, tmp.IsPermanent, tmp.Duration, tmp.Values, tmp.Icon);
                    break;
                case AuraTypes.HoT:
                    aura = new HoTAura(tmp.Id, AuraTypes.HoT, tmp.Name, tmp.IsVisible, tmp.IsPermanent, tmp.Duration, tmp.Values, tmp.Icon);
                    break;
                case AuraTypes.FlatBuff:
                    aura = new FlatBuffAura(tmp.Id, AuraTypes.FlatBuff, tmp.Name, tmp.IsVisible, tmp.IsPermanent, tmp.Duration, tmp.Values, tmp.Icon);
                    break;
                case AuraTypes.PercentBuff:
                    aura = new PercentBuffAura(tmp.Id, AuraTypes.PercentBuff, tmp.Name, tmp.IsVisible, tmp.IsPermanent, tmp.Duration, tmp.Values, tmp.Icon);
                    break;
                case AuraTypes.Other:
                    aura = new DummyAura(tmp.Id, AuraTypes.Other, tmp.Name, tmp.IsVisible, tmp.IsPermanent, tmp.Duration, tmp.Values, tmp.Icon);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            aura.SetCaster(caster);
            return aura;
        }
    }
}