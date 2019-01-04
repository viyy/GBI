using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Модель настроек игры
    /// </summary>
    public class SettingsModel : BaseModel
    {
        /// <summary>
        /// Хранилище настроек
        /// </summary>
        public Dictionary<string, string> Settings { get; }

        public SettingsModel()
        {
            Settings = new Dictionary<string, string>();
        }
    }
}