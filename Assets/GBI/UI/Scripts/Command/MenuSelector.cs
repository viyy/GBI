namespace Geekbrains
{
    /// <summary>
    /// Класс селектора команд
    /// </summary>
    internal class MenuSelector
    {
        /// <summary>
        /// Поле, хранящее ссылку на класс конкретной команды, реализующий интерфейс IMenuCommand
        /// </summary>
        private IMenuCommand _command;

        /// <summary>
        /// Метод, выбора команды
        /// </summary>
        /// <param name="command">Экземпляр класса, реализующего интерфейс IMenuCommand</param>
        internal void SetCommand(IMenuCommand command)
        {
            _command = command;
        }

        /// <summary>
        /// Метод, активации команды
        /// </summary>
        internal void Enable()
        {
            _command.Enable();
        }

        /// <summary>
        /// Метод дезактивации команды
        /// </summary>
        internal void Disable()
        {
            _command.Disable();
        }
    }
}

