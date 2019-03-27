using System.Collections.Generic;

namespace Geekbrains.Skills
{
    public class AuraDto
    {
        public int Id { get; set; }
        public AuraTypes Type { get; set; }
        public string Name { get; set; }
        public bool IsVisible { get; set; }
        public bool IsPermanent { get; set; }
        public float Duration { get; set; }
        public string Icon { get; set; }
        public Dictionary<CharacteristicTypes, float> Values { get; set; }
    }
}