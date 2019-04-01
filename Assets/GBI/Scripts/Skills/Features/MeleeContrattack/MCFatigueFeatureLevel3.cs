namespace Geekbrains
{
    /// <summary>
    /// Класс свойства усталости в контратаке уровень 1
    /// </summary>
    class MCFatigueFeatureLevel3 : SkillFeature, IFatigueFeature
    {
        public float Value { get; private set; } = -2f;
    }
}
