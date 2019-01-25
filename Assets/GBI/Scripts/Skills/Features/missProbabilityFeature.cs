namespace Geekbrains
{
    internal class MissProbabilityFeature : SkillFeature
    {
        private float _missProbability;

        private MissProbabilityFeature() { }

        internal MissProbabilityFeature(float missProbability)
        {
            _missProbability = missProbability;
        }

        internal override void SetValue(float value)
        {
            _missProbability = value;
        }

        internal override float GetValue() => _missProbability * _multiplier;
    }
}