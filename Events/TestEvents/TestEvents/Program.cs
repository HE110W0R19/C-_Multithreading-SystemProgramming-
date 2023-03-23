using System;
using System.Threading;

namespace TestEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var Rand = new Random();
            var ES = new EventSender();
            var Obs2 = new Observer2(1);
            var Obs3 = new Observer3[3] { new Observer3(2), new Observer3(3), new Observer3(4) };
            var Obs4 = new Observer4(5);

            while (true)
            {
                int Random = Rand.Next(0, 4);
                switch (Random)
                {
                    case 0:
                        ES.MakeEvent += Obs2.EventReaction;
                        ES.doEvent();
                        ES.MakeEvent -= Obs2.EventReaction;
                        break;
                    case 1:
                        var RandIndex = Rand.Next(0, 3);
                        ES.MakeEvent += Obs3[RandIndex].EventReaction;
                        ES.doEvent();
                        ES.MakeEvent -= Obs3[RandIndex].EventReaction;
                        break;
                    case 2:
                        ES.MakeEvent += Obs4.EventReaction;
                        ES.doEvent();
                        ES.MakeEvent -= Obs4.EventReaction;
                        break;
                }
            }
        }
    }
}
