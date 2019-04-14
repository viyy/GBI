using System.Collections.Generic;
using Geekbrains;
using Geekbrains.Skills;
using Geekbrains.Skills.Auras;

namespace DefaultNamespace
{
    public class QuestReward
    {
        public int Xp { get; private set; }
        
        public int Money { get; private set; }
        
        //TODO: Items base class
        public List<object> Items { get; private set; } = new List<object>();
        
        public List<int> Auras { get; private set; } = new List<int>();
        
        public List<object> Reputations { get; private set; } = new List<object>();

        public QuestReward(QuestRewardDto dto)
        {
            Xp = dto.Xp;
            Money = dto.Money;
            Auras = dto.Auras;
            //TODO: Items and reputation if any.

        }
    }
}