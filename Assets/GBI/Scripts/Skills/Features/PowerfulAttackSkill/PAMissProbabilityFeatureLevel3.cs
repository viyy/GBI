namespace Geekbrains
{
    /// <summary>
    /// Класс вероятности промаха уровень 3
    /// </summary>
    public class PAMissProbabilityFeatureLevel3 : SkillFeature, IMissProbabilityFeature
    {
        public float Value { get; private set; } = 0.7f;
    }
}