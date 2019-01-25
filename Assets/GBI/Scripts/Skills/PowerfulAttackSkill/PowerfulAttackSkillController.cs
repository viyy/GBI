namespace Geekbrains
{
    internal class PowerfulAttackSkillController : SkillController
    {
             

        internal PowerfulAttackSkillController(int id)
        {
            _model = new PowerfulAttackSkillModel(id);
            Register(_model);
        }

        internal void SetDamageMultiplier(float multiplier)
        {
            (_model as PowerfulAttackSkillModel).SetMultiplier<DamageFeature>(multiplier);
        }

        internal void SetMissProbabilityMultiplier(float multiplier)
        {
            (_model as PowerfulAttackSkillModel).SetMultiplier<MissProbabilityFeature>(multiplier);
        }

        internal void SetDamageValue(float value)
        {
            (_model as PowerfulAttackSkillModel).SetValue<DamageFeature>(value);
        }

        internal void SetMissProbabilityValue(float value)
        {
            (_model as PowerfulAttackSkillModel).SetValue<MissProbabilityFeature>(value);
        }
    }
}