namespace Geekbrains
{
    /// <summary>
    /// Класс урона скилла контратаки в контратаке уровня 2
    /// </summary>
    public class MCDamageFeatureLevel2 : SkillFeature, IDamageFeature
    {
        public float Value { get; private set; } = 2f;
    }
}
