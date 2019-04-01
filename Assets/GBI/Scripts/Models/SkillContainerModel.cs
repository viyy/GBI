using System;
using System.Collections.Generic;
using Geekbrains.Skills;

namespace Geekbrains
{
    public class SkillContainerModel : BaseModel, IRegistrator<Skill>, IUpdatable
    {
        private Dictionary<int, Skill> _skills = new Dictionary<int, Skill>();
        public void Register(Skill record)
        {
            if (!_skills.ContainsKey(record.Id)) _skills.Add(record.Id, record);
        }

        public void Unregister(Skill record)
        {
            _skills.Remove(record.Id);
        }

        public Skill this[int id] => _skills.ContainsKey(id) ? _skills[id] : null;
        public void OnUpdate(float deltaTime)
        {
            foreach (var value in _skills.Values)
            {
                value.OnUpdate(deltaTime);
            }
        }
    }
}