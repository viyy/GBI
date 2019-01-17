namespace Geekbrains
{
    /// <summary>
    /// Интерфейс команды меню
    /// </summary>
    internal interface IMenuCommand
    {
        /// <summary>
        /// Метод включения меню
        /// </summary>
        void Enable();

        /// <summary>
        /// Метод отключения меню
        /// </summary>
        void Disable();
    }
}