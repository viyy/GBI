using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using Geekbrains;

namespace GBI.Scripts.Quests
{
    public class QuestLogModel : BaseModel, IRegistrator<Quest>
    {
        private List<Quest> _quests = new List<Quest>();
        public void Register(Quest record)
        {
            _quests.Add(record);
        }

        public void Unregister(Quest record)
        {
            _quests.Remove(record);
        }

        public void RemoveById(int id)
        {
            var tmp = _quests.Find(x => x.Id == id);
            if (tmp!=null) Unregister(tmp);
        }

        public Quest this[int id] => _quests.Find(x => x.Id == id);

        public List<Quest> Quests => _quests;

        public List<Quest> GetByZone(int zoneId) => _quests.FindAll(x => x.ZoneId == zoneId);

        public List<Quest> GetByTaskType(QuestTaskTypes type) => _quests.FindAll(x => x.Tasks.Any(y => y.Type == type));

        public List<Quest> GetTracked() => _quests.FindAll(x => x.IsTracked);
    }
}