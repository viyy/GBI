using System.Collections.Generic;

namespace Geekbrains
{
    public class LocaleModel : BaseModel
    {
        public GameLanguageEnum                                         LanguageEnum    { get; set; }
        public Dictionary<GameLanguageEnum, Dictionary<string, string>> Dictionary      { get; set; }
        public Dictionary<string, string>                               CurrentLanguage => Dictionary[LanguageEnum];

        public LocaleModel()
        {
            Dictionary = new Dictionary<GameLanguageEnum, Dictionary<string, string>>();
            Dictionary.Add(GameLanguageEnum.RUSSIAN, new Dictionary<string, string>());
            Dictionary.Add(GameLanguageEnum.ENGLISH, new Dictionary<string, string>());
        }
    }
}