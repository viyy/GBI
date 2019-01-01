using UnityEngine;

namespace Geekbrains
{
    public class LocaleController : BaseController<LocaleModel>
    {
        public LocaleController(LocaleModel localeModel) : base(localeModel) {}

        public void SwitchLanguale(GameLanguageEnum languageEnum)
        {
            _model.LanguageEnum = languageEnum;
        }

        public void AddString(GameLanguageEnum languageEnum, string key, string text)
        {
            var dictionary = _model.Dictionary[languageEnum];

            if ( dictionary.ContainsKey(key) ) {
                Debug.LogWarning($"Locale already contains key {key}");

                return;
            }

            dictionary.Add(key, text);
        }

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