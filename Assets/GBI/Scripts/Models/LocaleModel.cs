using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Модель локализации
    /// </summary>
    public class LocaleModel : BaseModel
    {
        /// <summary>
        /// Текущий язык игры
        /// </summary>
        /// <see cref="GameLanguageEnum"/>
        public GameLanguageEnum LanguageEnum;

        /// <summary>
        /// Хранилище переводов
        /// </summary>
        public Dictionary<GameLanguageEnum, Dictionary<string, string>> Dictionary;

        /// <summary>
        /// Свойство текущего перевода
        /// </summary>
        public Dictionary<string, string> CurrentLanguage => Dictionary[LanguageEnum];

        public LocaleModel()
        {
            Dictionary = new Dictionary<GameLanguageEnum, Dictionary<string, string>>();
            Dictionary.Add(GameLanguageEnum.RUSSIAN, new Dictionary<string, string>());
            Dictionary.Add(GameLanguageEnum.ENGLISH, new Dictionary<string, string>());
        }
    }
}