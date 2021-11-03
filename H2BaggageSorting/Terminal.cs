using System;
using System.Collections.Generic;
using System.Text;

namespace H2BaggageSorting
{
    class Terminal
    {
        public DateTime GateOpen { get; set; }
        public DateTime GateClosed { get; set; }
        public int BaggageNumber { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
