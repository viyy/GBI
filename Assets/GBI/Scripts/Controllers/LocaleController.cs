using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера локализации <br/>
    /// Весь текст, выводящийся на экран, необходимо запрашивать только из этого класса. Иначе перевод игры будет наботать не верно
    /// </summary>
    /// <see cref="BaseController{T}"/>
    /// <see cref="LocaleModel"/>
    public class LocaleController : BaseController<LocaleModel>
    {
        public LocaleController(LocaleModel localeModel) : base(localeModel) {}

        /// <summary>
        /// Метод смены языка вывода
        /// </summary>
        /// <param name="languageEnum">Требуемый язык вывода</param>
        /// <see cref="GameLanguageEnum"/>
        public void SwitchLanguage(GameLanguageEnum languageEnum)
        {
            _model.LanguageEnum = languageEnum;
        }

        /// <summary>
        /// Метод добавления строки во внутреннюю базу 
        /// </summary>
        /// <param name="languageEnum">Язык добавляемой строки</param>
        /// <param name="key">Ключ для получения значения</param>
        /// <param name="text">Текс для вывода</param>
        /// <see cref="GameLanguageEnum"/>
        public void AddString(GameLanguageEnum languageEnum, string key, string text)
        {
            var dictionary = _model.Dictionary[languageEnum];

            if ( dictionary.ContainsKey(key) ) {
                LogWrapper.Warning($"Locale already contains key {key}");

                return;
            }

            dictionary.Add(key, text);
        }

        /// <summary>
        /// Метод получения текста по ключу с зависимостью от текущего выбранного языка
        /// </summary>
        /// <param name="key">Ключ для текста</param>
        /// <returns>Текст локализации</returns>
        public string GetText(string key)
        {
            string text = key;

            var currentLanguage = _model.CurrentLanguage;

            if ( currentLanguage.ContainsKey(key) ) {
                text = currentLanguage[key];
            }

            return text;
        }
    }
}