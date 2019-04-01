namespace Geekbrains
{
    /// <summary>
    /// Класс свойства защиты скилла уровень 1
    /// </summary>
    public class MDDefenceFeatureLevel1 : SkillFeature, IDefenceFeature
    {
        public float Value { get; private set; } = 1f;
    }
}
