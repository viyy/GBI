namespace Geekbrains
{
    /// <summary>
    /// Класс усталости от применения скилла уровня 4
    /// </summary>
    public class PAFatigueFeatureLevel4 : SkillFeature, IFatigueFeature
    {
        public float Value { get; private set; } = -1f;
    }
}
