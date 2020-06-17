using System;
using System.Collections.Generic;
using System.Text;

namespace Akka
{
    class FibonacciMessage
    {
        public long[] Fibonacci { get; set; }

        public int N_process { get; set; }

        public int StartIndex { get; set; }
    }
}
