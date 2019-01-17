using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Интерфейс параметров игры
    /// </summary>
    /// <typeparam name="T">Тип хранимых параметров</typeparam>
    internal interface IOptionsData<T>
    {
        /// <summary>
        /// Метод получения коллекции текущих значений параметров
        /// </summary>
        /// <returns>Ссылка на коллекцию параметров</returns>
        List<OptionsParameter<T>> GetOptions();

        /// <summary>
        /// Метод изменения значения параметра
        /// </summary>
        /// <param name="key">Ключ для именования параметра</param>
        /// <param name="parameterValue">Значение параметра</param>
        void ChangeParameter(string key, T parameterValue);
    }
}