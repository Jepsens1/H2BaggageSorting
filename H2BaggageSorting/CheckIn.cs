using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace H2BaggageSorting
{
    class CheckIn
    {
        public int PassageNumber { get; set; }
        public int BaggageNumber { get; set; }
        public DateTime CheckInTime { get; set; }
        Random r = new Random(Guid.NewGuid().GetHashCode());
        public static int lugggagecount;
        public static Luggage[] luggagebuffer = new Luggage[25];
        public CheckIn(DateTime _Checkin)
        {
            PassageNumber = GeneratePassaggeNumber();
            CheckInTime = _Checkin;
        }
        int GenerateBaggageNumber()
        {
            return r.Next(1, 100);
        }
        int GeneratePassaggeNumber()
        {
            return r.Next(1100, 10000);
        }
        public void StartCheckIn()
        {
            while (true)
            {
                try
                {
                    Monitor.Enter(SortHandler._lock);
                    if (lugggagecount == 25 || SortHandler.sortcount == 100)
                    {
                        Monitor.Wait(SortHandler._lock);
                    }
                    for (int i = 0; i < luggagebuffer.Length; i++)
                    {
                        if (luggagebuffer[i] == null)
                        {
                            BaggageNumber = GenerateBaggageNumber();
                            if (BaggageNumber <= 25)
                            {
                                luggagebuffer[i] = new Luggage(BaggageNumber, CheckInTime, Destination.London);
                                lugggagecount++;
                                //Console.WriteLine("Added to london");
                            }
                            else if (BaggageNumber > 25 && BaggageNumber <= 50)
                            {
                                luggagebuffer[i] = new Luggage(BaggageNumber, CheckInTime, Destination.Bayern);
                                lugggagecount++;
                                //Console.WriteLine("Added to Bayern");
                            }
                            else if (BaggageNumber > 50 && BaggageNumber <= 75)
                            {
                                luggagebuffer[i] = new Luggage(BaggageNumber, CheckInTime, Destination.Rome);
                                lugggagecount++;
                                //Console.WriteLine("Added to Rome");
                            }
                            else if (BaggageNumber > 75 && BaggageNumber <= 100)
                            {
                                luggagebuffer[i] = new Luggage(BaggageNumber, CheckInTime, Destination.Paris);
                                lugggagecount++;
                                //Console.WriteLine("Added to Paris");
                            }
                        }
                    }
                    Monitor.PulseAll(SortHandler._lock);
                    Thread.Sleep(5000);
                }
                finally
                {
                    Monitor.Exit(SortHandler._lock);
                }
            }
        }
    }

}
