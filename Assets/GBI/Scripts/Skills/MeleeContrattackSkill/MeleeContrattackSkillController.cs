namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера скилла "Контратака в ближнем бою"
    /// </summary>
    public class MeleeContrattackSkillController : SkillController
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

        private MeleeContrattackSkillController() { }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="id">Идентификатор скилла</param>
        /// <param name="level">Уровень скилла</param>
        public MeleeContrattackSkillController(int id, int level)
        {
            _model = new MeleeContrattackSkillModel(id);
            SetFeatures(level);
        }

        /// <summary>
        /// Метод получения значений свойств скилла
        /// </summary>
        /// <typeparam name="T">Интерфейс свойства скилла</typeparam>
        /// <returns>Значение свойства скилла</returns>
        public float GetValue<T>() where T : class, IFeature<float>
        {
            if (_model != null)
                return (_model as MeleeContrattackSkillModel).GetValue<T>();
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

        /// <summary>
        /// Метод установки свойств скилла
        /// </summary>
        /// <param name="level">Уровень скилла</param>
        private void SetFeatures(int level)
        {
            IsDamage = true;
            IsFatigue = true;
            CurrentLevel = level;
            switch (CurrentLevel)
            {
                case 1:
                    Register(_damageFeature = new MCDamageFeatureLevel1());
                    Register(_fatigueFeature = new MCFatigueFeatureLevel1());
                    break;
                case 2:
                    Unregister(_damageFeature);
                    Unregister(_fatigueFeature);
                    Register(_damageFeature = new MCDamageFeatureLevel2());
                    Register(_fatigueFeature = new MCFatigueFeatureLevel2());
                    break;
                case 3:
                    Unregister(_damageFeature);
                    Unregister(_fatigueFeature);
                    Register(_damageFeature = new MCDamageFeatureLevel3());
                    Register(_fatigueFeature = new MCFatigueFeatureLevel3());
                    break;
                case 4:
                    Unregister(_damageFeature);
                    Unregister(_fatigueFeature);
                    Register(_damageFeature = new MCDamageFeatureLevel4());
                    Register(_fatigueFeature = new MCFatigueFeatureLevel4());
                    break;
            }
        }
    }
}
