using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using GBI.Scripts.Events;
using GBI.Scripts.Events.Args;
using GBI.Scripts.Quests;
using Geekbrains.Unit;

namespace Geekbrains
{
    public class QuestLogController : BaseController<QuestLogModel>, IRegistrator<Quest>
    {
        private IDummyUnit _character;
        public QuestLogController(IDummyUnit character ,QuestLogModel model) : base(model)
        {
            _character = character;
            
            EventManager.StartListening(GameEventTypes.NpcDie, OnNpcDie);
            EventManager.StartListening(GameEventTypes.AreaEnter, OnAreaEnter);
        }
        
        public Quest this[int id] => _model.Quests.Find(x => x.Id == id);

        public List<Quest> Quests => _model.Quests;

        public List<Quest> GetByZone(int zoneId) => _model.Quests.FindAll(x => x.ZoneId == zoneId);

        public List<Quest> GetByTaskType(QuestTaskTypes type) => _model.Quests.FindAll(x => x.Tasks.Any(y => y.Type == type));

        public List<Quest> GetTracked() => _model.Quests.FindAll(x => x.IsTracked);
        public void Register(Quest record)
        {
            _model.Register(record);
        }

        public void Unregister(Quest record)
        {
            _model.Unregister(record);
        }

        public void QuestUpdate(QuestTaskTypes eventType, int targetId, int amount = 1)
        {
            foreach (var quest in GetByTaskType(eventType))
            {
                foreach (var task in quest.Tasks)
                {
                    if (task.Type!=eventType || task.TargetId!=targetId) continue;
                    task.AddAmount(amount);
                }
            }
        }

        private void OnNpcDie(EventArgs args)
        {
            if (!(args is NpcDieArgs dieArgs)) return;
            if (dieArgs.KillerIds.Contains(_character.Id))
            {
                QuestUpdate(QuestTaskTypes.KillNpc, dieArgs.Id);
            }
        }

        private void OnAreaEnter(EventArgs args)
        {
            if (!(args is IdArgs idArgs)) return;
            QuestUpdate(QuestTaskTypes.FindLocation, idArgs.Id);
        }
        
    }
}