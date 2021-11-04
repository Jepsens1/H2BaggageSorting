using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace H2BaggageSorting
{
    class Terminal
    {
        public DateTime GateOpen { get; set; }
        public DateTime GateClosed { get; set; }
        public int BaggageNumber { get; set; }
        public DateTime TimeStamp { get; set; }

        public Luggage[] termbuffer = new Luggage[25];
        public static int TerminalCount = 0;
        public void StartTerminal()
        {
            while (true)
            {
                try
                {
                    Monitor.Enter(SortHandler._lock);
                    if (TerminalCount == 25)
                    {
                        Monitor.Wait(SortHandler._lock);
                    }
                    for (int i = 0; i < SortHandler.buffer.Length; i++)
                    {
                        if (SortHandler.buffer[i] != null)
                        {
                            switch (SortHandler.buffer[i].Destination)
                            {
                                case Destination.London:
                                    termbuffer[i] = SortHandler.buffer[i];
                                    SortHandler.buffer[i] = null;
                                    TerminalCount++;
                                    Console.WriteLine("Flying to London");
                                    break;
                                case Destination.Bayern:
                                    termbuffer[i] = SortHandler.buffer[i];
                                    SortHandler.buffer[i] = null;
                                    TerminalCount++;
                                    Console.WriteLine("Flying to Bayern");
                                    break;
                                case Destination.Rome:
                                    termbuffer[i] = SortHandler.buffer[i];
                                    SortHandler.buffer[i] = null;
                                    TerminalCount++;
                                    Console.WriteLine("Flying to Rome");
                                    break;
                                case Destination.Paris:
                                    termbuffer[i] = SortHandler.buffer[i];
                                    SortHandler.buffer[i] = null;
                                    TerminalCount++;
                                    Console.WriteLine("Flying to Paris");
                                    break;
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
