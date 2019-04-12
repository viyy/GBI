using System.Collections.Generic;
using Geekbrains;
using Geekbrains.Skills;

namespace DefaultNamespace
{
    public class Quest : BaseModel, IRegistrator<QuestTask>
    {
        public int Id { get; private set; }
        
        public string Name { get; private set; }
        
        public string Description { get; private set; }

        public List<QuestTask> Tasks { get; } = new List<QuestTask>();

        public QuestReward Reward { get; private set; }

        public bool IsTracked { get; set; } = false;
        public int ZoneId { get; private set; }
        
        public List<QuestMarker> MapMarkers { get; private set; } = new List<QuestMarker>();

        public void Register(QuestTask record)
        {
            Tasks.Add(record);
        }

        public void Unregister(QuestTask record)
        {
            Tasks.Remove(record);
        }

        public Quest(QuestDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Description = dto.Description;
            ZoneId = dto.ZoneId;
            MapMarkers = dto.MapMarkers;
            foreach (var task in dto.Tasks)
            {
                Tasks.Add(new QuestTask(task));
            }
            Reward = new QuestReward(dto.Reward);
        }
    }
}