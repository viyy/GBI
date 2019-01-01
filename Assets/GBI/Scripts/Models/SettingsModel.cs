using System.Collections.Generic;

namespace Geekbrains {
    public class SettingsModel : BaseModel
    {
        private Dictionary<string, string> _settings;

        public Dictionary<string, string> Settings => _settings;

        public SettingsModel()
        {
            _settings = new Dictionary<string, string>();
        }
    }
}