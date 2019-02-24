using System;
using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Фабрика по созданию команд пользовательского ввода
    /// </summary>
    public static class InputCommandFactory
    {
        /// <summary>
        /// Словарь очередей команд для реализации пула команд
        /// </summary>
        private static readonly Dictionary<Type, Queue<InputCommand>> _commands;

        static InputCommandFactory()
        {
            _commands = new Dictionary<Type, Queue<InputCommand>>();
        }

        /// <summary>
        /// Метод получения команд <br/>
        /// При отсутствии команды в пуле - создается новая
        /// </summary>
        /// <typeparam name="T">Класс команды, который наследуется от InputCommand</typeparam>
        /// <returns>Объект команды</returns>
        /// <see cref="InputCommand"/>
        public static T GetCommand<T>()
            where T : InputCommand, new()
        {
            InputCommand        command = default(T);
            Queue<InputCommand> queue;

            _commands.TryGetValue(typeof(T), out queue);

            if ( queue?.Count > 0 ) {
                command = queue.Dequeue();
            }

            return (T) (command ?? new T());
        }

        /// <summary>
        /// Метод возвращения команды в пул
        /// </summary>
        /// <param name="command">Отработавшая команда</param>
        /// <typeparam name="T">Класс команды, который наследуется от InputCommand</typeparam>
        /// <see cref="InputCommand"/>
        public static void Realize<T>(T command)
            where T : InputCommand
        {
            Queue<InputCommand> queue;
            _commands.TryGetValue(command.CommandType, out queue);

            if ( queue == null ) {
                queue = new Queue<InputCommand>();
                _commands.Add(command.CommandType, queue);
            }

            queue.Enqueue(command);
        }
    }
}