using System;
using UnityEngine;

namespace Geekbrains
{
    public abstract class InputCommand
    {
        protected InputCommand()
        {
            _isEnabledInPause = false;
            _commandType      = GetType();

            InternalInitialize();
        }

        protected abstract void InternalExecute();

        protected abstract void InternalInitialize();

        protected bool _isEnabledInPause;

        internal Type _commandType;

        public void Execute()
        {
            if ( !Main.Instance.PauseController.IsPaused || _isEnabledInPause ) {
                try {
                    InternalExecute();
                } catch ( Exception e ) {
                    Debug.LogError(e);
                }
            }

            InputCommandFactory.Realize(this);
        }
    }
}