using System;
using System.Threading;
namespace H2BaggageSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            SortHandler sortHandler = new SortHandler();
            Thread CheckinThread = new Thread(sortHandler.CheckInStart);
            Thread SortHandlerThread = new Thread(sortHandler.SortLuggage);
            Thread TerminalThread = new Thread(sortHandler.StartTerminal);
            CheckinThread.Start();
            SortHandlerThread.Start();
            TerminalThread.Start();
        }
    }
}
