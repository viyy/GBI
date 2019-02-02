namespace Geekbrains
{
    /// <summary>
    /// Класс урона скилла уровня 4
    /// </summary>
    public class PADamageFeatureLevel4 : SkillFeature, IDamageFeature
    {
        public float Value { get; private set; } = 4f;
    }
}