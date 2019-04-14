using DefaultNamespace;

namespace Geekbrains.Skills
{
    public class TaskProgressDto
    {
        public QuestTaskTypes Type { get; set; }
        public int TargetId { get; set; }
        public int CurrentAmount { get; set; }
    }
}