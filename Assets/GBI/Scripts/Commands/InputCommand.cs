using System;
using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Базовый класс команды ввода
    /// </summary>
    public abstract class InputCommand
    {
        /// <summary>
        /// Будет ли обрабатываться команда во время паузы <br/>
        /// К примеру, для команды переключения паузы по нажатию ESC этот флаг должен быть true
        /// </summary>
        protected bool _isEnabledInPause;

        /// <summary>
        /// Тип текущей команды. При неправильных значениях - система может перестать работать 
        /// </summary>
        protected Type _commandType;

        public Type CommandType => _commandType;

        protected InputCommand()
        {
            _isEnabledInPause = false;
            _commandType      = GetType();

            InternalInitialize();
        }

        /// <summary>
        /// Метод для реализации каждой команды 
        /// </summary>
        protected abstract void InternalExecute();

        /// <summary>
        /// Метод для переопределения базовых значений команды <br/>
        /// _commandType обязательна для переопределения. Иначе система автоматического пула перестанет работать
        /// </summary>
        protected abstract void InternalInitialize();

        /// <summary>
        /// Метод запуска выполнения команды <br/>
        /// После выполенния команды - она автоматически возвращается в пул
        /// </summary>
        public void Execute()
        {
            if ( !Main.Instance.PauseController.IsPaused || _isEnabledInPause ) {
                try {
                    InternalExecute();
                } catch ( Exception e ) {
                    LogWrapper.Error(e);
                }
            }

            InputCommandFactory.Realize(this);
        }
    }
}