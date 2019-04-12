using System.Collections.Generic;
using DefaultNamespace;

namespace Geekbrains.Skills
{
    public class QuestDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public int ZoneId { get;  set; }
        
        public List<QuestMarker> MapMarkers { get; set; } = new List<QuestMarker>();
        
        public List<QuestTaskDto> Tasks { get; set; } = new List<QuestTaskDto>();
        
        public QuestRewardDto Reward { get; set; }
    }
}