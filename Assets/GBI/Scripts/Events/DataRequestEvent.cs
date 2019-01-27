using System;
using System.Collections.Generic;

namespace Geekbrains
{
    internal class DataRequestEvent : BaseEvent
    {
        internal SkillModel Source { get; private set; }

        internal DataRequestEvent(SkillModel source)
        {
            Source = source;
        }
    }
}