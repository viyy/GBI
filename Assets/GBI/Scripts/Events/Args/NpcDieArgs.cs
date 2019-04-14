using System;
using System.Collections.Generic;

namespace GBI.Scripts.Events.Args
{
    public class NpcDieArgs : EventArgs
    {
        public int Id { get; set; }
        public List<int> KillerIds { get; set; } = new List<int>();
    }
}