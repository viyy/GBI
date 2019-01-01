namespace Geekbrains
{
    /// <summary>
    /// Интерфейс для регистрации события обновления физического движка в главном классе
    /// </summary>
    /// <see cref="Geekbrains.Main"/>
    public interface IFixedUpdatable
    {
        /// <summary>
        /// Метод вызываемый во время обновления физического движка
        /// </summary>
        /// <param name="deltaTime">Разница во времени между предыдущим и текущим обновлениями физического движка</param>
        void OnFixedUpdate(float deltaTime);
    }
}