using System;
using System.Runtime.Serialization;

namespace Geekbrains
{
    [Serializable]
    public enum SkillEffectTypes
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        Damage = 1,
        [EnumMember]
        Heal = 2,
        [EnumMember]
        Vampirism = 3,
        [EnumMember]
        Aura = 4
    }
}