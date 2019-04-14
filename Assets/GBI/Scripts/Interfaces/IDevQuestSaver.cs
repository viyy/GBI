using GBI.Scripts.Dto;
using Geekbrains.Skills;

namespace Geekbrains
{
    public interface IDevQuestSaver
    {
        void SaveQuest(QuestDto dto);
        int GetNextId();
    }
}