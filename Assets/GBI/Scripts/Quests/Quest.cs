using System.Collections.Generic;
using GBI.Scripts.Dto;
using Geekbrains;
using Geekbrains.Skills;

namespace DefaultNamespace
{
    public class Quest : BaseModel, IRegistrator<QuestTask>
    {
        public int Id { get; }
        
        public List<int> RequiredQuests { get; }
        public string Name { get; }
        
        public string Description { get; }

        public List<QuestTask> Tasks { get; } = new List<QuestTask>();

        public QuestReward Reward { get; }

        public bool IsTracked { get; set; } = false;
        public int ZoneId { get; }
        
        public List<QuestMarker> MapMarkers { get; }

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
            MapMarkers = new List<QuestMarker>();
            foreach (var mapMarker in dto.MapMarkers)
            {
                MapMarkers.Add(new QuestMarker(mapMarker.MapId, mapMarker.X, mapMarker.Y));
            }
            RequiredQuests = dto.RequiredQuests;
            foreach (var task in dto.Tasks)
            {
                Tasks.Add(new QuestTask(task));
            }
            Reward = new QuestReward(dto.Reward);
        }
    }
}