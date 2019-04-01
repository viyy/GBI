using System;
using System.Runtime.Serialization;

namespace Geekbrains
{
    [Serializable]
    public enum AuraTypes
    {
        /// <summary>
        /// Deals damage over time
        /// </summary>
        [EnumMember] DoT = 1, 
        /// <summary>
        /// Heals over time
        /// </summary>
        [EnumMember] HoT = 2, 
        /// <summary>
        /// Both Affects stats, but different layers
        /// </summary>
        [EnumMember] FlatBuff = 3,
        [EnumMember] PercentBuff = 4,
        /// <summary>
        /// For inner purposes
        /// </summary>
        [EnumMember] Other = 5
    }
}