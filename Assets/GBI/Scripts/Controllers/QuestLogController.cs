using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using GBI.Scripts.Quests;

namespace Geekbrains
{
    public class QuestLogController : BaseController<QuestLogModel>, IRegistrator<Quest>
    {
        public QuestLogController(QuestLogModel model) : base(model)
        {
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
    }
}