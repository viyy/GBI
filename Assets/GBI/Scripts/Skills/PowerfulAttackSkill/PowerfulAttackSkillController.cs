using System;

namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера скилла "Мощная атака"
    /// </summary>
    public class PowerfulAttackSkillController : SkillController
    {
        /// <summary>
        /// Максимальный уровень скилла
        /// </summary>
        private const int maxLevel = 4;

        /// <summary>
        /// Ссылка на текущее свойство урона
        /// </summary>
        private SkillFeature _damageFeature;
        /// <summary>
        /// Ссылка на текущее свойство усталости
        /// </summary>
        private SkillFeature _fatigueFeature;

        /// <summary>
        /// Ссылка на текущее свойство вероятности промаха
        /// </summary>
        private SkillFeature _missProbabilityFeature;

        private PowerfulAttackSkillController() { }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="id">Идентификатор скилла</param>
        /// <param name="level">Уровень скилла</param>
        public PowerfulAttackSkillController(int id, int level)
        {
            _model = new PowerfulAttackSkillModel(id);
            SetFeatures(level);
        }

        /// <summary>
        /// Метод получения значений свойств скилла
        /// </summary>
        /// <typeparam name="T">Интерфейс свойства скилла</typeparam>
        /// <returns>Значение свойства скилла</returns>
        public float GetValue<T>() where T : class, IFeature<float>
        {
            if(_model != null)
                return (_model as PowerfulAttackSkillModel).GetValue<T>();
            return default;
        }

        /// <summary>
        /// Метод увеличения уровня скилла
        /// </summary>
        /// <returns>Результат выполнения true или false</returns>
        public bool Upgrade()
        {
            if (CurrentLevel == maxLevel)
                return false;
            CurrentLevel++;
            SetFeatures(CurrentLevel);
            return true;
        }

        private void SetFeatures(int level)
        {
            IsDamage = true;
            IsFatigue = true;
            IsMissProbability = true;
            CurrentLevel = level;
            switch (CurrentLevel)
            {
                case 1:
                    Register(_damageFeature = new PADamageFeatureLevel1());
                    Register(_fatigueFeature = new PAFatigueFeatureLevel1());
                    Register(_missProbabilityFeature = new PAMissProbabilityFeatureLevel1());
                    break;
                case 2:
                    Unregister(_damageFeature);
                    Unregister(_fatigueFeature);
                    Unregister(_missProbabilityFeature);
                    Register(_damageFeature = new PADamageFeatureLevel2());
                    Register(_fatigueFeature = new PAFatigueFeatureLevel2());
                    Register(_missProbabilityFeature = new PAMissProbabilityFeatureLevel2());
                    break;
                case 3:
                    Unregister(_damageFeature);
                    Unregister(_fatigueFeature);
                    Unregister(_missProbabilityFeature);
                    Register(_damageFeature = new PADamageFeatureLevel3());
                    Register(_fatigueFeature = new PAFatigueFeatureLevel3());
                    Register(_missProbabilityFeature = new PAMissProbabilityFeatureLevel3());
                    break;
                case 4:
                    Unregister(_damageFeature);
                    Unregister(_fatigueFeature);
                    Unregister(_missProbabilityFeature);
                    Register(_damageFeature = new PADamageFeatureLevel4());
                    Register(_fatigueFeature = new PAFatigueFeatureLevel4());
                    Register(_missProbabilityFeature =new PAMissProbabilityFeatureLevel4());
                    break;
            }
        }
    }
}