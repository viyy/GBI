namespace Geekbrains
{
    /// <summary>
    /// Класс усталости от применения скилла уровня 3
    /// </summary>
    public class PAFatigueFeatureLevel3 : SkillFeature, IFatigueFeature
    {
        public float Value { get; private set; } = -2f;
    }
}
