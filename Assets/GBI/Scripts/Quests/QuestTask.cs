namespace DefaultNamespace
{
    public class QuestTask
    {
        public QuestTaskTypes Type { get; private set; }
        
        public int TargetId { get; private set; }
        
        public int NeededAmount { get; private set; }
        
        public int CurrentAmount { get; private set; }

        public bool IsCompleted => CurrentAmount < NeededAmount;
    }
}