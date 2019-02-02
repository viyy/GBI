namespace Geekbrains
{
    /// <summary>
    /// Класс урона скилла уровня 2
    /// </summary>
    public class PADamageFeatureLevel2 : SkillFeature, IDamageFeature
    {
        public float Value { get; private set; } = 2f;
    }
}