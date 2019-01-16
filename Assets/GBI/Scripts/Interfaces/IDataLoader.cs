using System.Collections.Generic;

/// <summary>
/// Интерфейс загрузчика данных
/// </summary>
/// <typeparam name="T">Тип загружаемых параметров</typeparam>
internal interface IDataLoader<T>
{
    /// <summary>
    /// Метод, возвращающий загруженные данные в виде стека
    /// </summary>
    /// <param name="path">Источник данных</param>
    /// <returns>Стэк, загруженных из источника значений</returns>
    Stack<T> LoadDataToStack(string path);

    /// <summary>
    /// Метод, возвращающий загруженные данные в виде коллекции
    /// </summary>
    /// <param name="path">Источник данных</param>
    /// <returns>Коллекция, загруженных из источника значений</returns>
    List<T> LoadDataToList(string path);

    /// <summary>
    /// Метод, возвращающий загруженные данные в виде очереди
    /// </summary>
    /// <param name="path">Источник данных</param>
    /// <returns>Очередь, загруженных из источника значений</returns>
    Queue<T> LoadDataToQueue(string path);
}
