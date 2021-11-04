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
        public void StartTerminal(object locke, Luggage[] buffer, Destination destination)
        {
            
            while (true)
            {
                try
                {
                    Monitor.Enter(locke);
                    if (termbuffer.Length == 50)
                    {
                        Monitor.Wait(locke);
                    }
                    switch (destination)
                    {
                        case Destination.London:
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
                    Monitor.Exit(locke);
                }
            }
        }
    }
}
