namespace Geekbrains
{
    /// <summary>
    /// Класс свойства усталости скилла уровень 1
    /// </summary>
    public class MDFatigueFeatureLevel1 : SkillFeature, IFatigueFeature
    {
        public float Value { get; private set; } = -4f;
    }
}
