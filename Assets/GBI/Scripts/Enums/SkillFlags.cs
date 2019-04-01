using System;
using System.Runtime.Serialization;

namespace Geekbrains
{
    [Flags, Serializable]
    public enum SkillFlags
    {
        [EnumMember]
        None = 0x0,
        [EnumMember]
        Damage = 0x1,
        [EnumMember]
        Heal = 0x2,
        [EnumMember]
        Melee = 0x4,
        [EnumMember]
        Range = 0x8,
        [EnumMember]
        Aoe = 0x10,
        [EnumMember]
        Spell = 0x20,
        [EnumMember]
        Craft = 0x40,
        [EnumMember]
        Projectile = 0x80
    }
}