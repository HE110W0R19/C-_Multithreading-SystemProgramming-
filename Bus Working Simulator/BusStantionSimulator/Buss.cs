using System;
using System.Threading;

namespace BusStantionSimulator
{
    class Buss
    {
        //private Thread BussThread;
        private Random Rand = new Random();
        private TimeSpan RoadTime;
        private int BussID;

        public Buss(TimeSpan NewAllTimes, int bussId)
        {
            //BussThread = new Thread(new ThreadStart(StartBuss));
            //this.BussID = this.BussThread.ManagedThreadId;
            this.BussID = bussId;
            this.RoadTime = NewAllTimes;
        }

        public void BussMessageAccepter(TownWatch OutTownWatch)
        {
            Console.WriteLine($"Buss: {this.BussID} bus has arrived!");
            this.RoadTime = new TimeSpan(0, 0, Rand.Next(1, 10));
            BussThrowMessage(OutTownWatch);
            //OutTownWatch.AddNewTime(getBussID, getRoadTime);
        }

        public void BussThrowMessage(TownWatch OutTownWatch)
        {
            Console.WriteLine($"This Buss[{BussID}] send message! Next stantion in: {RoadTime.Seconds}\n\n");
            OutTownWatch.AddNewTime(this.getBussID, this.getRoadTime);
        }

        public TimeSpan getRoadTime
        {
            get
            {
                return RoadTime;
            }
        }
        public int getBussID
        {
            get
            {
                return BussID;
            }
        }
    }
}
