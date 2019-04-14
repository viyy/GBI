using Geekbrains.Skills;

namespace DefaultNamespace
{
    public class QuestTask
    {
        public QuestTaskTypes Type { get; private set; }
        
        public int TargetId { get; private set; }
        
        public int NeededAmount { get; private set; }

        public int CurrentAmount { get; private set; } = 0;

        public bool IsCompleted => CurrentAmount >= NeededAmount;

        public void AddAmount(int amount) => CurrentAmount += amount;

        public QuestTask(QuestTaskDto dto)
        {
            Type = dto.Type;
            TargetId = dto.TargetId;
            NeededAmount = dto.NeededAmount;
        }
    }
}