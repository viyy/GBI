using System;
using System.Runtime.Serialization;

namespace Geekbrains
{
    [Serializable]
    public enum CharacteristicTypes
    {
        [EnumMember] Int = 1,
        [EnumMember] Str = 2,
        [EnumMember] Con = 3
    }
}