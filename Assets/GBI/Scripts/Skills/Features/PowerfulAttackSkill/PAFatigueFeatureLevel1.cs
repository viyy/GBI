namespace Geekbrains
{
    /// <summary>
    /// Класс усталости от применения скилла уровня 1
    /// </summary>
    public class PAFatigueFeatureLevel1 : SkillFeature, IFatigueFeature
    {
        public float Value { get; private set; } = -4f;
    }
}
