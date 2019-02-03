namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера скилла "Защита в ближнем бою"
    /// </summary>
    public class MeleeDefenceSkillController : SkillController
    {
        /// <summary>
        /// Максимальный уровень скилла
        /// </summary>
        private const int maxLevel = 4;

        /// <summary>
        /// Ссылка на текущее свойство защиты
        /// </summary>
        private SkillFeature _defenceFeature;

        /// <summary>
        /// Ссылка на текущее свойство усталости
        /// </summary>
        private SkillFeature _fatigueFeature;

        private MeleeDefenceSkillController() { }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="id">Идентификатор скилла</param>
        /// <param name="level">Уровень скилла</param>
        public MeleeDefenceSkillController(int id, int level)
        {
            _model = new MeleeDefenceSkillModel(id);
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
            IsDefence = true;
            IsFatigue = true;
            CurrentLevel = level;
            switch (CurrentLevel)
            {
                case 1:
                    Register(_defenceFeature = new MDDefenceFeatureLevel1());
                    Register(_fatigueFeature = new MDFatigueFeatureLevel1());
                    break;
                case 2:
                    Unregister(_defenceFeature);
                    Unregister(_fatigueFeature);
                    Register(_defenceFeature = new MDDefenceFeatureLevel2());
                    Register(_fatigueFeature = new MDFatigueFeatureLevel2());
                    break;
                case 3:
                    Unregister(_defenceFeature);
                    Unregister(_fatigueFeature);
                    Register(_defenceFeature = new MDDefenceFeatureLevel3());
                    Register(_fatigueFeature = new MDFatigueFeatureLevel3());
                    break;
                case 4:
                    Unregister(_defenceFeature);
                    Unregister(_fatigueFeature);
                    Register(_defenceFeature = new MDDefenceFeatureLevel4());
                    Register(_fatigueFeature = new MDFatigueFeatureLevel4());
                    break;
            }
        }
    }
}
