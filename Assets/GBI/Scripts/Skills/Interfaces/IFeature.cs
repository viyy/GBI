namespace Geekbrains
{
    /// <summary>
    /// Базовый интерфейс для свойств скиллов
    /// </summary>
    /// <typeparam name="T">Тип хранимого значения свойства скилла</typeparam>
    public interface IFeature<T>
    {
        T Value { get; }
    }
}
