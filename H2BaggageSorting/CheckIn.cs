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
        int number;
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
                            int destination = GenerateBaggageNumber();
                            if (destination <= 25)
                            {
                                luggagebuffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.London);
                                SortHandler.buffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.London);
                                lugggagecount++;
                                SortHandler.sortcount++;
                                number++;
                            }
                            else if (destination > 25 && destination <= 50)
                            {
                                luggagebuffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.Bayern);
                                SortHandler.buffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.Bayern);
                                lugggagecount++;
                                SortHandler.sortcount++;
                                number++;
                            }
                            else if (destination > 50 && destination <= 75)
                            {
                                luggagebuffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.Rome);
                                SortHandler.buffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.Rome);
                                lugggagecount++;
                                SortHandler.sortcount++;
                                number++;
                            }
                            else if (destination > 75 && destination <= 100)
                            {
                                luggagebuffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.Paris);
                                SortHandler.buffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.Paris);
                                lugggagecount++;
                                SortHandler.sortcount++;
                                number++;
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
