using System;
using Geekbrains.Unit;

namespace GBI.Scripts.Events.Args
{
    public class IdArgs : EventArgs
    {
        public int Id { get; set; }
        
        public int TriggeredUnitId { get; set; }
    }
}