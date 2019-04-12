using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using DefaultNamespace;
using Geekbrains;
using Geekbrains.Skills;

namespace GBI.Scripts.Storage
{
    public class XmlQuestStorage : IQuestStorage
    {
        private const string BasePath = "Assets/GBI/Data/Quests/";
        private const string QuestPrefix = "q_";
        private const string TaskPrefix = "t_";
        private const string Suffix = ".xml";
        public Quest GetQuest(int id)
        {
            var serializer = new XmlSerializer(typeof(QuestDto));
            var reader = new StreamReader(GetQuestFilePath(id));
            var dQuestDto = (QuestDto)serializer.Deserialize(reader.BaseStream);
            reader.Close();
            serializer = new XmlSerializer(typeof(List<TaskProgressDto>));
            reader = new StreamReader(GetQuestProgressFilePath(id));
            var dProgressDto = (List<TaskProgressDto>) serializer.Deserialize(reader.BaseStream);
            reader.Close();
            return MakeQuest(dQuestDto, dProgressDto);
        }

        private Quest MakeQuest(QuestDto questDto, IEnumerable<TaskProgressDto> progressDto)
        {
            var res = new Quest(questDto);
            foreach (var taskInfo in progressDto)
            {
                res.Tasks.Find(x => x.Type == taskInfo.Type && x.TargetId == taskInfo.TargetId)?.AddAmount(taskInfo.CurrentAmount);
            }

            return res;
        }
        
        private static string GetQuestFilePath(int id)
        {
            return BasePath + QuestPrefix + id + Suffix;
        }

        private static string GetQuestProgressFilePath(int id)
        {
            return BasePath + TaskPrefix + id + Suffix;
        }
    }
}