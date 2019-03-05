using System;

namespace Geekbrains
{
    [Flags]
    public enum TargetModeTypes
    {
        None = 0,
        Enemy = 0x1,
        Ally = 0x2,
        Self = 0x4 
    }
}