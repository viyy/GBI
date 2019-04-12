using System.Collections.Generic;
using Geekbrains.Skills.Auras;

namespace DefaultNamespace
{
    public class QuestReward
    {
        public int QuestId { get; private set; }
        
        public int Xp { get; private set; }
        
        public int Money { get; private set; }
        
        //TODO: Items base class
        public List<object> Items { get; private set; } = new List<object>();
        
        //public List<AuraBase> Auras { get; private set; } = new List<AuraBase>();
        
        public List<object> Reputations { get; private set; } = new List<object>();
    }
}