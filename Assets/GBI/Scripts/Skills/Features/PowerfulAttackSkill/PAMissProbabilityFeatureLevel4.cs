namespace Geekbrains
{
    /// <summary>
    /// Класс вероятности промаха уровень 4
    /// </summary>
    public class PAMissProbabilityFeatureLevel4 : SkillFeature, IMissProbabilityFeature
    {
        public float Value { get; private set; } = 0.8f;
    }
}