using DefaultNamespace;

namespace Geekbrains
{
    public interface IQuestStorage
    {
        /// <summary>
        /// Get quest with saved progress 
        /// </summary>
        /// <param name="id">Quest Id</param>
        /// <param name="unitId">Unit Id for retrieve saved progress</param>
        /// <returns></returns>
        Quest GetQuest(int id, int unitId);
    }
}