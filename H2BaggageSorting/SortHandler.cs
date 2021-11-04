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

        Terminal terminal1 = new Terminal();
        Terminal terminal2 = new Terminal();
        Terminal terminal3 = new Terminal();
        Terminal terminal4 = new Terminal();
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
                    if (sortcount == 100)
                    {
                        Monitor.Wait(_lock);
                    }
                    for (int i = 0; i < CheckIn.luggagebuffer.Length; i++)
                    {
                        if (CheckIn.luggagebuffer[i] != null)
                        {
                            if (CheckIn.luggagebuffer[i].BaggageNumber <= 25)
                            {
                                buffer[i] = new Luggage(BaggageNumber, CheckInTime, Destination.London);
                                sortcount++;
                            }
                            else if (CheckIn.luggagebuffer[i].BaggageNumber > 25 && CheckIn.luggagebuffer[i].BaggageNumber <= 50)
                            {
                                buffer[i] = new Luggage(BaggageNumber, CheckInTime, Destination.Bayern);
                                sortcount++;
                            }
                            else if (CheckIn.luggagebuffer[i].BaggageNumber > 50 && CheckIn.luggagebuffer[i].BaggageNumber <= 75)
                            {
                                buffer[i] = new Luggage(BaggageNumber, CheckInTime, Destination.Rome);
                                sortcount++;
                            }
                            else if (CheckIn.luggagebuffer[i].BaggageNumber > 75 && CheckIn.luggagebuffer[i].BaggageNumber <= 100)
                            {
                                buffer[i] = new Luggage(BaggageNumber, CheckInTime, Destination.Paris);
                                sortcount++;
                            }
                        }
                    }
                    Monitor.PulseAll(_lock);
                    Thread.Sleep(5000);
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
        }
        public void StartTerminal()
        {

        }
    }
}
