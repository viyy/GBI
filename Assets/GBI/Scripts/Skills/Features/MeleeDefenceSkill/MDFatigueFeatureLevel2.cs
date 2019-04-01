namespace Geekbrains
{
    /// <summary>
    /// Класс свойства усталости скилла уровень 2
    /// </summary>
    public class MDFatigueFeatureLevel2 : SkillFeature, IFatigueFeature
    {
        public float Value { get; private set; } = -3f;
    }
}
