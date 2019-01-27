namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера скилла "Мощная атака"
    /// </summary>
    internal sealed class PowerfulAttackSkillController : SkillController
    {
        /// <summary>
        /// Конструктор класса PowerfulAttackSkillController
        /// </summary>
        /// <param name="id">Идентификатор скилла</param>
        internal PowerfulAttackSkillController(int id)
        {
            _model = new PowerfulAttackSkillModel(id);
            Register(_model);
        }

        /// <summary>
        /// Метод установки множителя урона, для применения мутогенов и временных усилений/ослаблений
        /// </summary>
        /// <param name="multiplier">Значение множителя (1f соответствует 100% урону от данного скилла)</param>
        internal void SetDamageMultiplier(float multiplier)
        {
            (_model as PowerfulAttackSkillModel).SetMultiplier<DamageFeature>(multiplier);
        }

        /// <summary>
        /// Метод установки множителя вероятности промаха
        /// </summary>
        /// <param name="multiplier">Значение множителя (1f соответствует 100% успешности мощной атаки)</param>
        internal void SetMissProbabilityMultiplier(float multiplier)
        {
            (_model as PowerfulAttackSkillModel).SetMultiplier<MissProbabilityFeature>(multiplier);
        }

        /// <summary>
        /// Метод установки значения базового урона от мощной атаки
        /// </summary>
        /// <param name="value">Значение урона</param>
        internal void SetDamageValue(float value)
        {
            (_model as PowerfulAttackSkillModel).SetValue<DamageFeature>(value);
        }

        /// <summary>
        /// Метод установки базового значения вероятности промаха
        /// </summary>
        /// <param name="value">Значение вероятности промаха</param>
        internal void SetMissProbabilityValue(float value)
        {
            (_model as PowerfulAttackSkillModel).SetValue<MissProbabilityFeature>(value);
        }
    }
}