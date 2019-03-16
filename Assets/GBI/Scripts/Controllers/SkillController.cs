using System.Collections.Generic;
using Geekbrains.Skills;
using Geekbrains.Unit;

namespace Geekbrains
{
    public class SkillController: BaseController<SkillContainerModel>, IUpdatable, IRegistrator<Skill>
    {
        private ITargetManager _tm;
        private IAnimationManager _am;
        public SkillController(IDummyUnit caster, ITargetManager tm, IAnimationManager am)
        {    
            _caster = caster;
            _targets = new List<IDummyUnit>();
            _tm = tm;
            _am = am;
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

        public void Register(Skill record)
        {
            _model.Register(record);
        }

        public void Unregister(Skill record)
        {
            _model.Unregister(record);
        }
        
        public bool IsCasting { get; private set; }
        
        public float CurrentCastTime { get; private set; }
        
        public float CastTime { get; private set; }

        public Skill GetSkill(int id) => _model[id];
        
        public Skill CurrentSkill { get; private set; }

        private IDummyUnit _caster;

        private List<IDummyUnit> _targets;

        public async void Cast(int id)
        {
            var tmp = GetSkill(id);    
            if (tmp==null) return;
            CurrentSkill = tmp;
            _targets = await _tm.GetTargets(_caster, CurrentSkill);
            IsCasting = true;
            CastTime = tmp.CastTime;
            CurrentCastTime = 0;
        }

        public async void Cast(Skill skill)
        {
            CurrentSkill = skill;
            _targets = await _tm.GetTargets(_caster, CurrentSkill);
            IsCasting = true;
            CastTime = skill.CastTime;
            CurrentCastTime = 0;
        }

        public void Execute()
        {
            
        }
    }
}