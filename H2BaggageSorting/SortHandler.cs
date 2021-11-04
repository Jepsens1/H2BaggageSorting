using System;
using System.Collections.Generic;
using System.Text;

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

        Random r = new Random(Guid.NewGuid().GetHashCode());
        object _lock = new object();
        public static Luggage[] buffer = new Luggage[100];

        public void CheckInStart()
        {
            CheckIn checkIn = new CheckIn(CheckInTime);
            checkIn.StartCheckIn(_lock,(Destination)GenerateRandomDestination());
        }
        public void SortLuggage()
        {
        }
        public void TerminalStart()
        {
        }
        public int GenerateRandomDestination()
        {
            return r.Next(0, 3);
        }
    }
}
