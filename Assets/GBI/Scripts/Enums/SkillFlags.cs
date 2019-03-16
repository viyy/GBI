using System;

namespace Geekbrains
{
    [Flags]
    public enum SkillFlags
    {
        None = 0x0,
        Damage = 0x1,
        Heal = 0x2,
        Melee = 0x4,
        Range = 0x8,
        Aoe = 0x10,
        Spell = 0x20,
        Craft = 0x40,
        Projectile = 0x80
    }
}