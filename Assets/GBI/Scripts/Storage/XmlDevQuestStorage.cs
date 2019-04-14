using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using DefaultNamespace;
using GBI.Scripts.Dto;
using Geekbrains;
using Geekbrains.Skills;

namespace GBI.Scripts.Storage
{
    public class XmlDevQuestStorage : IQuestStorage, IDevQuestSaver
    {
        private const string BasePath = "Assets/GBI/Data/Quests/";
        private const string QuestPrefix = "q_";
        private const string TaskPrefix = "t_";
        private const string Suffix = ".xml";
        public Quest GetQuest(int id, int unitId)
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

        public void SaveQuest(QuestDto dto)
        {
            dto.Id = GetNextId();
            var serializer = new XmlSerializer(typeof(QuestDto));
            var writer = new StreamWriter(GetQuestFilePath(dto.Id));
            serializer.Serialize(writer.BaseStream, dto);
            writer.Close();
        }

        public int GetNextId()
        {
            var dir = new DirectoryInfo(BasePath);
            var info = dir.GetFiles("*"+Suffix);
            var tmp = new List<int> {0};
            foreach (var f in info)
            {
                if (int.TryParse(f.Name.Remove(0,2), out var i))
                {
                    tmp.Add(i);
                }
            }
            tmp.Sort();
            return tmp.Last()+1;
        }
    }
}