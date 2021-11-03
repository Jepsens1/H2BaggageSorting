using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace H2BaggageSorting
{
    public enum Destination
    {
        London,
        Copenhaegen,
        Bayern,
        Rome,
        Paris
    }
    class CheckIn
    {
        public int PassageNumber { get; set; }
        
        public int BaggageNumber { get; set; }

        public Destination destination { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }

        public CheckIn(int _PassageNumber, int _BaggageNumber, DateTime _Checkin, DateTime _Checkout)
        {
            PassageNumber = _PassageNumber;
            BaggageNumber = _BaggageNumber;
            CheckInTime = _Checkin;
            CheckOutTime = _Checkout;
        }
        Random r = new Random(Guid.NewGuid().GetHashCode());
        public void StartCheckIn(DateTime checkintime, DateTime checkouttime, int baggageNumber, byte[] terminalBuffer)
        {
            while (true)
            {
                try
                {
                    Monitor.Enter(terminalBuffer);
                    if (terminalBuffer.Length == 15)
                    {
                        Monitor.Wait(terminalBuffer);
                        Console.WriteLine("Terminal luggage is full");
                    }
                    switch (destination)
                    {
                        case Destination.London:
                            break;
                        case Destination.Copenhaegen:
                            break;
                        case Destination.Bayern:
                            break;
                        case Destination.Rome:
                            break;
                        case Destination.Paris:
                            break;
                        default:
                            break;
                    }
                }
                finally
                {

                }
            }
        }
    }
}
