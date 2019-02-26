using System.Collections.Generic;

namespace Geekbrains.Skills
{
    public class SkillDto
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Название скилла
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Радиус применения
        /// </summary>
        public float Range { get; set; }
        
        /// <summary>
        /// Стоимость навыка
        /// </summary>
        public Dictionary<int, int> Cost { get; set; }
        
        /// <summary>
        /// Флаги, указывающие на тип и особенности скилла
        /// </summary>
        public int Flags { get; set; }
        
        /// <summary>
        /// Список эффектов, которые будут применяться к цели
        /// </summary>
        public List<SkillEffectDto> Effects { get; set; }
    }
}