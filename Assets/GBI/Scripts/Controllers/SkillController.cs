using System.Collections.Generic;
using Geekbrains.Skills;
using Geekbrains.Unit;

namespace Geekbrains
{
    /// <summary>
    /// Контролирует модель умений, отслеживает прогресс применения умений
    /// </summary>
    public class SkillController : BaseController<SkillContainerModel>, IUpdatable, IRegistrator<Skill>
    {
        /// <summary>
        /// (WIP) отвечает за запуск снарядов.
        /// TODO: продумать взаимодействие с этим компонентом.
        /// (DI)
        /// </summary>
        private readonly ISkillProjectileManager _am;

        /// <summary>
        /// Ссылка на юнита-кастера.
        /// TODO: заменить на IUnit, когда его сделают.
        /// </summary>
        private readonly IDummyUnit _caster;

        /// <summary>
        /// список целей, по которым будет применено умение.
        /// (WIP) в случае нонтаргет системы возможно не понадобится.
        /// </summary>
        private List<IDummyUnit> _targets;
        
        /// <summary>
        /// (WIP) Отвечает за захват целей в игровом пространстве.
        /// (DI)
        /// </summary>
        private readonly ITargetManager _tm;

        public SkillController(IDummyUnit caster, ITargetManager tm, ISkillProjectileManager am, SkillContainerModel model) : base(model)
        {
            _caster = caster;
            _targets = new List<IDummyUnit>();
            _tm = tm;
            _am = am;
        }

        /// <summary>
        /// Находится-ли сейчас какое-то умение в процессе применения
        /// </summary>
        public bool IsCasting { get; private set; }

        /// <summary>
        /// Текущее время подготовки/произнесения умения 
        /// </summary>
        public float CurrentCastTime { get; private set; }

        /// <summary>
        /// время, необходимое на подготовку умения. (произнесение заклинания)
        /// </summary>
        public float CastTime { get; private set; }

        /// <summary>
        /// Умение, которое подготавливается в данный момент
        /// </summary>
        public Skill CurrentSkill { get; private set; }

        public void Register(Skill record)
        {
            _model.Register(record);
        }

        public void Unregister(Skill record)
        {
            _model.Unregister(record);
        }

        public void OnUpdate(float deltaTime)
        {
            _model.OnUpdate(deltaTime);
            if (!IsCasting) return;
            CurrentCastTime += deltaTime;
            if (!(CurrentCastTime >= CastTime)) return;
            Execute();
            CurrentSkill = null;
            CurrentCastTime = 0;
            CastTime = 0;
            IsCasting = false;
            _targets = new List<IDummyUnit>();
        }

        /// <summary>
        /// Получает скилл из модели
        /// </summary>
        /// <param name="id">Id умения</param>
        /// <returns>Умение или null, если нет умения с таким Id</returns>
        public Skill GetSkill(int id)
        {
            return _model[id];
        }

        /// <summary>
        /// Начинает подготовку умения
        /// </summary>
        /// <param name="id">Id умения</param>
        public async void Cast(int id)
        {
            var tmp = GetSkill(id);
            if (tmp == null) return;
            CurrentSkill = tmp;
            _targets = await _tm.GetTargets(_caster, CurrentSkill);
            IsCasting = true;
            CastTime = tmp.CastTime;
            CurrentCastTime = 0;
        }

        /// <summary>
        /// Начинает подготовку умения
        /// </summary>
        /// <param name="skill">Умение</param>
        public async void Cast(Skill skill)
        {
            CurrentSkill = skill;
            _targets = await _tm.GetTargets(_caster, CurrentSkill);
            IsCasting = true;
            CastTime = skill.CastTime;
            CurrentCastTime = 0;
        }
        /// <summary>
        /// Выполняется запуск снарядов и визуальных составляющих умения.
        /// </summary>
        public void Execute()
        {
            //Проверка легальности целей
            _targets = _tm.VerifyTargets(_caster, CurrentSkill, _targets);
            //Skill.Execute вызывется на попадании конкретным снарядом.
            _am.LaunchSkill(CurrentSkill, _caster, _targets);
        }
    }
}