using System.Collections;
using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Класс модели меню настроек управления
    /// </summary>
    internal class ControlOptionsModel
    {
        /// <summary>
        /// Поле, хранящее ссылку на экземпляр класса ControlOptionsModel (реализация Singletone)
        /// </summary>
        private static ControlOptionsModel _instance = null;

        /// <summary>
        /// Свойство для доступа к ссылке на экземпляр класса ControlOptionsModel (реализация Singletone)
        /// </summary>
        public static ControlOptionsModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ControlOptionsModel();
                return _instance;
            }
        }

        /// <summary>
        /// Конструктор класса ControlOptionsModel
        /// </summary>
        private ControlOptionsModel() { }
    }
}