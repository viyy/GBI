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
        Range = 0x10,
        Aoe = 0x20,
        Spell = 0x40,
        Craft = 0x100,
        Channel = 0x200,
        Projectile = 0x400
    }
}