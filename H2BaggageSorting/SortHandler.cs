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
                                CheckIn.luggagebuffer[i] = null;
                                buffer[i] = new Luggage(BaggageNumber, CheckInTime, Destination.London);
                                sortcount++;
                                Console.WriteLine("Sorted and added to Terminal 1");
                            }
                            else if (CheckIn.luggagebuffer[i].BaggageNumber > 25 && CheckIn.luggagebuffer[i].BaggageNumber <= 50)
                            {
                                CheckIn.luggagebuffer[i] = null;
                                buffer[i] = new Luggage(BaggageNumber, CheckInTime, Destination.Bayern);
                                sortcount++;
                                Console.WriteLine("Sorted and added to Terminal 2");
                            }
                            else if (CheckIn.luggagebuffer[i].BaggageNumber > 50 && CheckIn.luggagebuffer[i].BaggageNumber <= 75)
                            {
                                CheckIn.luggagebuffer[i] = null;
                                buffer[i] = new Luggage(BaggageNumber, CheckInTime, Destination.Rome);
                                sortcount++;
                                Console.WriteLine("Sorted and added to Terminal 3");
                            }
                            else if (CheckIn.luggagebuffer[i].BaggageNumber > 75 && CheckIn.luggagebuffer[i].BaggageNumber <= 100)
                            {
                                CheckIn.luggagebuffer[i] = null;
                                buffer[i] = new Luggage(BaggageNumber, CheckInTime, Destination.Paris);
                                sortcount++;
                                Console.WriteLine("Sorted and added to Terminal 4");
                            }
                        }
                    }
                    Monitor.PulseAll(_lock);
                    Thread.Sleep(1000);
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
        }
        public void StartTerminal()
        {
            terminal1.StartTerminal();
        }
    }
}
