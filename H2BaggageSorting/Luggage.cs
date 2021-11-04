using System;
using System.Collections.Generic;
using System.Text;

namespace H2BaggageSorting
{
    class Luggage
    {
        public int BaggageNumber { get; set; }

        public DateTime Timestamp { get; set; }

        public Luggage(int _baggage, DateTime _time, Destination destination)
        {
            BaggageNumber = _baggage;
            Timestamp = _time;
        }
    }
}
