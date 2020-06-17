using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Akka
{
    public static class ProcessingData
    {
        const string OUTPUT_FILE = @"C:\Users\Vadim\Source\ADA\Lab1\moutput-actor.txt";

        private static int _n_Process;
        private static int _n_Processed;
        private static Stopwatch _stopWatch;

        public static void Init(int n_process)
        {
            _n_Process = n_process;
            _n_Processed = 0;
            _stopWatch = Stopwatch.StartNew();
        }

        public static void ValideNumber()
        {

            if (_n_Processed >= _n_Process)
            {
                _stopWatch.Stop();
                Console.WriteLine($"{_stopWatch.ElapsedMilliseconds} milliseconds");

                Fibonacci.WriteFile(OUTPUT_FILE, result);
                _n_Processed = 0;
            }
        }
    }
}
