using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Geekbrains.Skills;

namespace Geekbrains.Storages
{
    public class XmlSkillStorage : ISkillStorage, ISkillSaver
    {
        private const string BasePath = "Assets/GBI/Data/Skills/";
        private const string Suffix = ".xml";
        private const int Capacity = 100;
        private static readonly Dictionary<int, SkillDto> _cache = new Dictionary<int, SkillDto>(Capacity);
        public SkillDto GetSkillInfo(int id)
        {
            if (_cache.ContainsKey(id)) return _cache[id];
            if (_cache.Count>Capacity) _cache.Clear();
            var serializer = new XmlSerializer(typeof(SkillDto));
            var reader = new StreamReader(BasePath+id+Suffix);
            var deserialized = (SkillDto)serializer.Deserialize(reader.BaseStream);
            _cache.Add(id, deserialized);
            reader.Close();
            return deserialized;
        }

        public void SaveSkill(SkillDto dto)
        {
            var serializer = new XmlSerializer(typeof(SkillDto));
            var writer = new StreamWriter(BasePath+dto.Id+Suffix);
            serializer.Serialize(writer.BaseStream, dto);
            writer.Close();
        }

        public int GetNewId()
        {
            var dir = new DirectoryInfo(BasePath);
            var info = dir.GetFiles("*"+Suffix);
            var tmp = new List<int>();
            tmp.Add(0);
            foreach (var f in info)
            {
                if (int.TryParse(f.Name, out var i))
                {
                    tmp.Add(i);
                }
            }
            tmp.Sort();
            return tmp.Last();
        }
    }
}