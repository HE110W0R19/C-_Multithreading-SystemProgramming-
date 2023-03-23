using System;
using System.Collections.Generic;
using System.Threading;

namespace BusStantionSimulator
{
    //public delegate void EventDelegate();
    class TownWatch
    {
        //public event EventDelegate MessageTreatment = null;
        //private Thread MessageSender;
        private List<Buss> AllBuss;
        private Dictionary<int, TimeSpan> BussTimes;
        object block = new object();
        public TownWatch(List<Buss> TownBusses)
        {
            this.AllBuss = new List<Buss>();
            this.BussTimes = new Dictionary<int, TimeSpan>();
            foreach (var buff in TownBusses)
            {
                this.AllBuss.Add(buff);
                //this.BussTimes.Add(buff.getBussID, buff.getRoadTime);
            }
        }

        public void FindFirstBuss(TownWatch OutTownWatch)
        {
            UInt16 FirstBussIndex = 0;
            for (UInt16 i = 0; i < 3; ++i)
            {
                if (BussTimes[FirstBussIndex].Seconds > BussTimes[i].Seconds)
                {
                    FirstBussIndex = i;
                }
            }
            for (UInt16 i = 0; i < 3; ++i)
            {
                if (i != FirstBussIndex)
                {
                    BussTimes[i] = new TimeSpan(0, 0, BussTimes[i].Seconds - BussTimes[FirstBussIndex].Seconds);
                }
            }
            Thread.Sleep((BussTimes[FirstBussIndex].Seconds) * 1000);
            BussTimes.Remove(FirstBussIndex);
            TownMessageSender(AllBuss[FirstBussIndex], OutTownWatch);
        }

        public void AddNewTime(int InerBussID, TimeSpan NewTime)
        {
            BussTimes.Add(InerBussID, NewTime);
        }
        public void TownMessageSender(Buss SendBuss, TownWatch townWatch)
        {
            lock (block)
            {
                Console.WriteLine($"Town send arrive message to {SendBuss.getBussID}!");
                SendBuss.BussMessageAccepter(townWatch);
            }
        }
        public void TownMessageAccepter(Buss AcceptBuss, TownWatch townWatch)
        {
            Console.WriteLine($"Town accept time: {AcceptBuss.getRoadTime} from buss: {AcceptBuss.getBussID}!");
            TownMessageSender(AcceptBuss, townWatch);
        }
    }
}
