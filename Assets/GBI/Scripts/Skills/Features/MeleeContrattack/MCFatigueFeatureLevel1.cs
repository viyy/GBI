namespace Geekbrains
{
    /// <summary>
    /// Класс свойства усталости в контратаке уровень 1
    /// </summary>
    class MCFatigueFeatureLevel1 : SkillFeature, IFatigueFeature
    {
        public float Value { get; private set; } = -4f;
    }
}
