namespace Geekbrains
{
    /// <summary>
    /// Класс свойства усталости в контратаке уровень 2
    /// </summary>
    class MCFatigueFeatureLevel2 : SkillFeature, IFatigueFeature
    {
        public float Value { get; private set; } = -3f;
    }
}
