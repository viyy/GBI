namespace Geekbrains {
    public class SettingsController : BaseController<SettingsModel>
    {
        public SettingsController(SettingsModel settingsModel) : base(settingsModel) {}

        public void LoadFromFile()
        {
            // А почему бы и нет?
        }

        public string GetSetting(string key)
        {
            var value = key;
            _model.Settings.TryGetValue(key, out value);

            return value;
        }
    }
}