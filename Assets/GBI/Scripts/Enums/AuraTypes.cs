namespace Geekbrains
{
    public enum AuraTypes
    {
        /// <summary>
        /// Deals damage over time
        /// </summary>
        DoT = 1, 
        /// <summary>
        /// Heals over time
        /// </summary>
        HoT = 2, 
        /// <summary>
        /// Both Affects stats, but different layers
        /// </summary>
        FlatBuff = 3,
        PercentBuff = 4,
        /// <summary>
        /// For inner purposes
        /// </summary>
        Other = 5
    }
}