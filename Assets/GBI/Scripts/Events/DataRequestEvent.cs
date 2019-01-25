using System;
using System.Collections.Generic;

namespace Geekbrains
{
    internal class DataRequestEvent : BaseEvent
    {
        internal event Func<SkillModel, List<SkillFeature>> OnDataRequestEvent;

        internal List<SkillFeature> Invoke(SkillModel source)
        {
            return OnDataRequestEvent?.Invoke(source);
        }
    }
}