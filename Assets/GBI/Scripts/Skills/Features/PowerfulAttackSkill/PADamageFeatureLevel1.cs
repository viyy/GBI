namespace Geekbrains
{
    /// <summary>
    /// Класс урона скилла уровня 1
    /// </summary>
    public class PADamageFeatureLevel1 : SkillFeature, IDamageFeature
    {
        public float Value { get; private set; } = 1f;
    }
}