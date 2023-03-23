using System;
using System.Collections.Generic;



namespace BusStantionSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //City Busses
            Buss CityBuss1 = new Buss(new TimeSpan(0, 0, 5),0);
            Buss CityBuss2 = new Buss(new TimeSpan(0, 0, 3),1);
            Buss CityBuss3 = new Buss(new TimeSpan(0, 0, 7),2);

            //City TownWatch
            TownWatch MyCityTownWatch = new TownWatch(new List<Buss> { CityBuss1, CityBuss2, CityBuss3 });

            CityBuss1.BussThrowMessage(MyCityTownWatch);
            CityBuss2.BussThrowMessage(MyCityTownWatch);
            CityBuss3.BussThrowMessage(MyCityTownWatch);

            while (true)
            {
                MyCityTownWatch.FindFirstBuss(MyCityTownWatch);
            }
        }
    }
}
