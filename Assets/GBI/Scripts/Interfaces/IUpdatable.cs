namespace Geekbrains
{
    /// <summary>
    /// Интерфейс для регистрации события смены кадра в главном классе
    /// </summary>
    /// <see cref="Geekbrains.Main"/>
    public interface IUpdatable
    {
        /// <summary>
        /// Метод вызываемый во время смены кадра
        /// </summary>
        /// <param name="deltaTime">Разница во времени между предыдущим и текущим кадрами</param>
        void OnUpdate(float deltaTime);
    }
}