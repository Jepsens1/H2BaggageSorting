using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace H2BaggageSorting
{
    public enum Destination
    {
        London,
        Bayern,
        Rome,
        Paris
    }
    class SortHandler
    {
        public static int sortcount;
        public int BaggageNumber { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public static object _lock = new object();
        public static Luggage[] buffer = new Luggage[100];

        Random r = new Random(Guid.NewGuid().GetHashCode());

        public void CheckInStart()
        {
            CheckIn checkIn = new CheckIn(DateTime.Now);
            checkIn.StartCheckIn();
        }
        public void SortLuggage()
        {
            while (true)
            {
                try
                {
                    Monitor.Enter(_lock);
                }
                finally
                {

                }
            }

        }
        public void TerminalStart()
        {
        }

    }
}
