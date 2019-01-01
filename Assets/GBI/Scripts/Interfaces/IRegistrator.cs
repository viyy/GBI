namespace Geekbrains
{
    /// <summary>
    /// Интерфейс регистратора
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRegistrator<T>
    {
        /// <summary>
        /// Метод для регистрации регистрируемого объекта <br/>
        /// Результат регистрации зависит от реализации конкретногой реализации
        /// </summary>
        /// <param name="record">Объект, который необходимо зарегистрировать</param>
        void Register(T record);

        /// <summary>
        /// Метод для дерегистрации регистрируемого объекта <br/>
        /// Результат дерегистрации зависит от реализации конкретногой реализации
        /// </summary>
        /// <param name="record">Объект, который необходимо зарегистрировать</param>
        void Unregister(T record);
    }
}