namespace Geekbrains
{
    /// <summary>
    /// Класс свойства усталости в контратаке уровень 1
    /// </summary>
    class MCFatigueFeatureLevel4 : SkillFeature, IFatigueFeature
    {
        public float Value { get; private set; } = -1f;
    }
}
