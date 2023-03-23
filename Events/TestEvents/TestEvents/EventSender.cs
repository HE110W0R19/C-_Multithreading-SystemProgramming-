using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEvents
{
    class EventSender
    {
        public delegate void EventDelegate();
        public event EventDelegate MakeEvent;
        public void doEvent()
        {
            MakeEvent.Invoke();
        }
    }
}
