using System;
using System.Runtime.Serialization;

namespace Geekbrains
{
    [Flags, Serializable]
    public enum TargetModeTypes
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        Enemy = 0x1,
        [EnumMember]
        Ally = 0x2,
        [EnumMember]
        Self = 0x4 
    }
}