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
        
        public List<AuraBase> Auras { get; private set; } = new List<AuraBase>();
        
        public List<object> Reputations { get; private set; } = new List<object>();

        public QuestReward(QuestRewardDto dto)
        {
            Xp = dto.Xp;
            Money = dto.Money;
            foreach (var auraId in dto.Auras)
            {
                //TODO: think about caster
                Auras.Add(AuraFactory.GetAura(auraId, null));
            }
            //TODO: Items and reputation if any.

        }
    }
}