using System;

namespace Geekbrains
{
    [Flags]
    public enum SkillFlags
    {
        None = 0,
        Damage = 1,
        Heal = 2,
        Melee = 4,
        Range = 8,
        Aoe = 16,
        Spell = 32,
        Craft = 64,
        Channel = 128,
        Projectile = 256
    }
}