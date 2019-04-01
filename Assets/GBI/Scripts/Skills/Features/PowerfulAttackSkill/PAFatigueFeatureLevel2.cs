namespace Geekbrains
{
    /// <summary>
    /// Класс усталости от применения скилла уровня 2
    /// </summary>
    public class PAFatigueFeatureLevel2 : SkillFeature, IFatigueFeature
    {
        public float Value { get; private set; } = -3f;
    }
}
