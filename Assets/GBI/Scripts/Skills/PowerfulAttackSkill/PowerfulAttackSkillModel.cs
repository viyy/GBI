using System.Collections.Generic;

namespace Geekbrains
{
    internal class PowerfulAttackSkillModel : SkillModel
    {
        internal List<SkillFeature> SkillFeatures;

        private const float _damageDefault = 5f;

        private const float _missProbabilityDefault = 0.5f;

        private DataRequestEvent _dataRequestEvent = new DataRequestEvent();

        internal PowerfulAttackSkillModel(int id) : base(id)
        {
            LoadDefault();

            DispatchEvent(_dataRequestEvent);

            SkillFeatures = _dataRequestEvent?.Invoke(this);

            for (int i = 0; i < SkillFeatures.Count; i++)
            {
                if (SkillFeatures[i] != null)
                    Register(SkillFeatures[i]);
            }
        }

        internal void SetMultiplier<T>(float multiplier) where T : SkillFeature
        {
            for(int i=0; i < _features.Count; i++)
            {
                if(_features[i] is T)
                {
                    _features[i].SetMultiplier(multiplier);
                    break;
                }
            }
        }

        internal void SetValue<T>(float value) where T : SkillFeature
        {
                for (int i = 0; i < _features.Count; i++)
                {
                    if (_features[i] is T)
                    {
                        _features[i].SetValue(value);
                        break;
                    }
                }
        }

        internal float GetValue<T>() where T : SkillFeature
        {
            float value = default;
            for (int i = 0; i < _features.Count; i++)
            {
                if (_features[i] is T)
                {
                    value = _features[i].GetValue();
                }
            }
            return value;
        }

        private void LoadDefault()
        {
            SkillFeatures.Add(new DamageFeature(_damageDefault));
            SkillFeatures.Add(new MissProbabilityFeature(_missProbabilityDefault));
        }      
    }
}