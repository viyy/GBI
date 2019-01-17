using System.Collections;
using System.Collections.Generic;


namespace Geekbrains
{
    /// <summary>
    /// Класс модели меню настроек геймплея
    /// </summary>
    internal class GameplayOptionsModel
    {
        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса GameplayOptionsModel (реализация Singletone)
        /// </summary>
        private static GameplayOptionsModel _instance = null;

        /// <summary>
        /// Свойство для доступа к ссылке на экземпляр класса GameplayOptionsModel (реализация Singletone)
        /// </summary>
        internal static GameplayOptionsModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameplayOptionsModel();
                return _instance;
            }
        }
    }
}