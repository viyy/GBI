namespace Geekbrains
{
    /// <summary>
    /// Класс урона скилла контратаки в контратаке уровня 4
    /// </summary>
    public class MCDamageFeatureLevel4 : SkillFeature, IDamageFeature
    {
        public float Value { get; private set; } = 4f;
    }
}
