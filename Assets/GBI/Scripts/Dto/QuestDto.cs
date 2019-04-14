using System.Collections.Generic;
using Geekbrains.Skills;

namespace GBI.Scripts.Dto
{
    public class QuestDto
    {
        public int Id { get; set; }
        
        public List<int> RequiredQuests { get; set; } = new List<int>();
        public string Name { get; set; }
        
        public string Description { get; set; }

        public int ZoneId { get;  set; }
        
        public List<QuestMarkerDto> MapMarkers { get; set; } = new List<QuestMarkerDto>();
        
        public List<QuestTaskDto> Tasks { get; set; } = new List<QuestTaskDto>();
        
        public QuestRewardDto Reward { get; set; } = new QuestRewardDto();
    }
}