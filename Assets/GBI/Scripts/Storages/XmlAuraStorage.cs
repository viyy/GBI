using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Geekbrains.Skills;

namespace Geekbrains.Storages
{
    public class XmlAuraStorage : IAuraStorage
    {
        private const string BasePath = "Data/Skills/";
        private const string Suffix = ".xml";
        private const int Capacity = 100;
        private static readonly Dictionary<int, AuraDto> _cache = new Dictionary<int, AuraDto>(Capacity);
        public AuraDto GetAuraInfo(int id)
        {
            if (_cache.ContainsKey(id)) return _cache[id];
            if (_cache.Count>Capacity) _cache.Clear();
            var serializer = new XmlSerializer(typeof(AuraDto));
            var reader = new StreamReader(BasePath+id+Suffix);
            var deserialized = (AuraDto)serializer.Deserialize(reader.BaseStream);
            _cache.Add(id, deserialized);
            reader.Close();
            return deserialized;
        }
    }
}