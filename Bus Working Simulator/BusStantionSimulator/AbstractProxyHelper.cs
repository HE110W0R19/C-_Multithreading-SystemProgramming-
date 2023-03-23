using System;
using System.Collections.Generic;
using System.Threading;

namespace BusStantionSimulator
{
    abstract class AbstractProxyHelper
    {
        private bool isWork = false;
        Thread HelperThread;
        List<Action> MessageActionList;
        public AbstractProxyHelper()
        {
            this.MessageActionList = new List<Action>();
            this.HelperThread = new Thread(ThreadWork);
        }

        public void Invoke(Action input_actions)
        {
            this.MessageActionList.Add(input_actions);
        }
        public void ThreadWork()
        {
            while (MessageActionList.Count != 0)
            {

            }
        }
        public void Start()
        {
            this.isWork = true;
        }
        public void Stop()
        {
            this.isWork = false;
        }
    }
}
