namespace Geekbrains
{
    /// <summary>
    /// Класс урона скилла контратаки в контратаке уровня 3
    /// </summary>
    public class MCDamageFeatureLevel3 : SkillFeature, IDamageFeature
    {
        public float Value { get; private set; } = 3f;
    }
}
