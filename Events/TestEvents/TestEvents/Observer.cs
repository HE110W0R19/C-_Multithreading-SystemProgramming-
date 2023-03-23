using System;
using System.Threading;

namespace TestEvents
{
    abstract class Observer
    {
        public UInt16 ClassID;
        public virtual void EventReaction() { }
    }
    class Observer2 : Observer
    {
        public Observer2(UInt16 ID)
        {
            this.ClassID = ID;
        }
        public override void EventReaction()
        {
            Console.WriteLine("Event 2 принят.");
            Thread.Sleep(1000);
        }
    }

    class Observer3 : Observer
    {
        public Observer3(UInt16 ID)
        {
            this.ClassID = ID;
        }
        public override void EventReaction()
        {
            Console.WriteLine($"Event 3 принят классом с ID: {this.ClassID}");
            Thread.Sleep(1000);
        }
    }
    class Observer4 : Observer
    {
        public Observer4(UInt16 ID)
        {
            this.ClassID = ID;
        }
        public override void EventReaction()
        {
            Console.WriteLine("Event 4...");
            Thread.CurrentThread.Join();
        }
    }
}
