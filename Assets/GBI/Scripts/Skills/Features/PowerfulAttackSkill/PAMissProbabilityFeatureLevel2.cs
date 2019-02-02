namespace Geekbrains
{
    /// <summary>
    /// Класс вероятности промаха уровень 2
    /// </summary>
    public class PAMissProbabilityFeatureLevel2 : SkillFeature, IMissProbabilityFeature
    {
        public float Value { get; private set; } = 0.6f;
    }
}