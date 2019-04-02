using System;

namespace DefaultNamespace
{
    [Serializable]
    public enum QuestTaskTypes
    {
        None = 0,
        KillNpc = 1,
        CollectItem = 2,
        TalkWithNpc = 3,
        UseObject = 4,
        FindLocation = 5
    }
}