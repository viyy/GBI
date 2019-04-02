using System.Collections.Generic;
using Geekbrains;

namespace DefaultNamespace
{
    public class Quest : BaseModel, IRegistrator<QuestTask>
    {
        public int Id { get; private set; }
        
        public string Name { get; private set; }
        
        public string Description { get; private set; }

        private List<QuestTask> _tasks = new List<QuestTask>();
        
        public QuestReward Reward { get; private set; }
        
        public List<QuestMarker> MapMarkers { get; private set; } = new List<QuestMarker>();

        public void Register(QuestTask record)
        {
            _tasks.Add(record);
        }

        public void Unregister(QuestTask record)
        {
            _tasks.Remove(record);
        }
    }
}