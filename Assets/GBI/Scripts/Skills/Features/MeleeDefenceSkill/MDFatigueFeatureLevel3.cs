namespace Geekbrains
{
    /// <summary>
    /// Класс свойства усталости скилла уровень 3
    /// </summary>
    public class MDFatigueFeatureLevel3 : SkillFeature, IFatigueFeature
    {
        public float Value { get; private set; } = -2f;
    }
}
