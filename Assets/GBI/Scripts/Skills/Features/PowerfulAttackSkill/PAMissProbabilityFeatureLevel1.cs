namespace Geekbrains
{
    /// <summary>
    /// Класс вероятности промаха уровень 1
    /// </summary>
    public class PAMissProbabilityFeatureLevel1 : SkillFeature, IMissProbabilityFeature
    {
        public float Value { get; private set; } = 0.5f;
    }
}