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

        public Luggage[] termbuffer = new Luggage[50];
        public static int TerminalCount;
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
                       
                    }
                    
                }
                finally
                {
                    Monitor.Exit(SortHandler._lock);
                }
            }
        }
    }
}
