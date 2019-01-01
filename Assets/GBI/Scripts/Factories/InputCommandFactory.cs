using System;
using System.Collections.Generic;

namespace Geekbrains
{
    public static class InputCommandFactory
    {
        static InputCommandFactory()
        {
            _commands = new Dictionary<Type, Queue<InputCommand>>();
        }

        private static readonly Dictionary<Type, Queue<InputCommand>> _commands;

        public static T GetCommand<T>()
            where T : InputCommand, new()
        {
            InputCommand        command = default(T);
            Queue<InputCommand> queue;

            _commands.TryGetValue(typeof(T), out queue);

            if ( _commands?.Count > 0 ) {
                command = queue.Dequeue();
            }

            return (T) (command ?? new T());
        }

        public static void Realize<T>(T command)
            where T : InputCommand
        {
            Queue<InputCommand> queue;
            _commands.TryGetValue(command._commandType, out queue);

            if ( queue == null ) {
                queue = new Queue<InputCommand>();
                _commands.Add(command._commandType, queue);
            }

            queue.Enqueue(command);
        }
    }
}