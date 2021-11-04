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
        public static int lugcount;
        public static Luggage[] lugbuffer = new Luggage[25];
        public CheckIn(DateTime _Checkin)
        {
            PassageNumber = GeneratePassaggeNumber();
            BaggageNumber = GenerateBaggageNumber();
            CheckInTime = _Checkin;
        }
        int GenerateBaggageNumber()
        {
            return r.Next(1, 1000);
        }
        int GeneratePassaggeNumber()
        {
            return r.Next(1100, 10000);
        }
        public void StartCheckIn(object locke, Destination destination)
        {
            while (true)
            {
                try
                {
                    Monitor.Enter(locke);
                    if (lugcount == 25 || SortHandler.sortcount == 100)
                    {
                        Monitor.Wait(locke);
                    }
                    for (int i = 0; i < lugbuffer.Length; i++)
                    {
                        if (lugbuffer[i] == null)
                        {
                            switch (destination)
                            {
                                case Destination.London:
                                    lugbuffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.London);
                                    SortHandler.buffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.London);
                                    lugcount++;
                                    SortHandler.sortcount++;
                                    number++;
                                    break;
                                case Destination.Bayern:
                                    lugbuffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.Bayern);
                                    SortHandler.buffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.Bayern);
                                    lugcount++;
                                    SortHandler.sortcount++;
                                    number++;
                                    break;
                                case Destination.Rome:
                                    lugbuffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.Rome);
                                    SortHandler.buffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.Rome);
                                    lugcount++;
                                    SortHandler.sortcount++;
                                    number++;
                                    break;
                                case Destination.Paris:
                                    lugbuffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.Paris);
                                    SortHandler.buffer[number] = new Luggage(BaggageNumber, CheckInTime, Destination.Paris);
                                    lugcount++;
                                    SortHandler.sortcount++;
                                    number++;
                                    break;
                            }
                        }
                    }
                   
                    Monitor.PulseAll(locke);
                    Thread.Sleep(5000);
                }
                finally
                {
                    Monitor.Exit(locke);
                }
            }
        }
    }
}
