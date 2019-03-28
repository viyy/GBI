using System;
using System.Runtime.Serialization;

namespace Geekbrains
{
    /// <summary>
    /// Ресурсы юнитов, такие как мана, энергия ярость и прочее
    /// </summary>
    [Serializable]
    public enum ResourceTypes
    {
        [EnumMember]
        Mana = 1,
        [EnumMember]
        Energy = 2,
        [EnumMember]
        Rage = 3
    }
}