namespace Geekbrains
{
    /// <summary>
    /// Класс урона скилла контратаки в контратаке уровня 1
    /// </summary>
    public class MCDamageFeatureLevel1 : SkillFeature, IDamageFeature
    {
        public float Value { get; private set; } = 1f;
    }
}
