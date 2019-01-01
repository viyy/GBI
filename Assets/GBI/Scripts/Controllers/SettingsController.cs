namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера настроек
    /// </summary>
    /// <see cref="BaseController{T}"/> <br/>
    /// <see cref="SettingsModel"/>
    public class SettingsController : BaseController<SettingsModel>
    {
        public SettingsController(SettingsModel settingsModel) : base(settingsModel) { }

        /// <summary>
        /// Метод пакетной загрузки настроек из файла
        /// </summary>
        public void LoadFromFile()
        {
            
        }

        /// <summary>
        /// Метод получения текущей настройки по ключу
        /// </summary>
        /// <param name="key">Ключ настройки</param>
        /// <returns>Значение настройки</returns>
        public string GetSetting(string key)
        {
            var value = key;
            _model.Settings.TryGetValue(key, out value);

            return value;
        }
    }
}