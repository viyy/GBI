namespace Geekbrains
{
    /// <summary>
    /// Класс свойства усталости скилла уровень 4
    /// </summary>
    public class MDFatigueFeatureLevel4 : SkillFeature, IFatigueFeature
    {
        public float Value { get; private set; } = -1f;
    }
}
