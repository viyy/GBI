using DefaultNamespace;

namespace Geekbrains.Skills
{
    public class QuestTaskDto
    {
        public QuestTaskTypes Type { get; set; }
        
        public int TargetId { get; set; }
        
        public int NeededAmount { get; set; }
    }
}