using System.Collections.Generic;

namespace Geekbrains.Skills
{
    public class QuestRewardDto
    {
        public int QuestId { get; set; }
        
        public int Xp { get; set; }
        
        public int Money { get; set; }
        
        //TODO: Items base class
       // public List<object> Items { get; private set; } = new List<object>();
        
        public List<AuraDto> Auras { get; private set; } = new List<AuraDto>();
        
        //public List<object> Reputations { get; private set; } = new List<object>();
    }
}