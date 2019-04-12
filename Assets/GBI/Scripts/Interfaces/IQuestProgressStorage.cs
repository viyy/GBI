using System.Collections.Generic;
using Geekbrains.Skills;

namespace Geekbrains
{
    public interface IQuestProgressStorage
    {
        List<TaskProgressDto> GetQuestProgress(int unitId ,int questId);
        void SaveQuestProgress(int unitId, int questId, List<TaskProgressDto> progress);
    }
}