namespace Geekbrains
{
    /// <summary>
    /// Класс параметра игры
    /// </summary>
    /// <typeparam name="T">Тип хранимого значения</typeparam>
    internal class OptionsParameter<T>
    {
        /// <summary>
        /// Поле, хранящее ключ для именования параметра
        /// </summary>
        private string _key;

        /// <summary>
        /// Поле, хранящее значение параметра заданного типа T 
        /// </summary>
        private T _parameterValue;

        /// <summary>
        /// Свойство для доступа к ключу для именования параметра
        /// </summary>
        internal string GetKey => _key;

        /// <summary>
        /// Свойство для доступа к значению параметра
        /// </summary>
        internal T GetValue => _parameterValue;

        /// <summary>
        /// Конструктор класса OptionsParameter
        /// </summary>
        /// <param name="key">Ключ для именования параметра</param>
        /// <param name="parameterValue">Значение параметра</param>
        internal OptionsParameter(string key, T parameterValue)
        {
            _key = key;
            _parameterValue = parameterValue;
        }

        /// <summary>
        /// Метод изменения ключа для именования параметра
        /// </summary>
        /// <param name="newKey">Новое значение ключа для именования параметра</param>
        internal void ChangeKey(string newKey)
        {
            _key = newKey;
        }

        /// <summary>
        /// Метод изменения значения параметра
        /// </summary>
        /// <param name="newValue">Новое значение параметра</param>
        internal void ChangeValue(T newValue)
        {
            _parameterValue = newValue;
        }
    }
}