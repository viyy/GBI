using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class MenuSelector
    {
        private IMenuCommand _command;

        internal MenuSelector() { }

        internal void SetCommand(IMenuCommand command)
        {
            _command = command;
        }

        internal void Enable()
        {
            _command.Enable();
        }

        internal void Disable()
        {
            _command.Disable();
        }
    }
}

