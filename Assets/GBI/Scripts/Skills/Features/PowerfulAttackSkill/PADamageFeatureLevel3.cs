namespace Geekbrains
{
    /// <summary>
    /// Класс урона скилла уровня 3
    /// </summary>
    public class PADamageFeatureLevel3 : SkillFeature, IDamageFeature
    {
        public float Value { get; private set; } = 3f;
    }
}