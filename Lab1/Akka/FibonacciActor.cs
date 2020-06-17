using System;
using Akka.Actor;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Akka
{
    class FibonacciActor: UntypedActor
    {
        protected override void OnReceive(object message)
        {
            GetFibonacci((FibonacciMessage)message);
        }

        protected override void PreStart()
        {
           
        }

        protected override void PostStop()
        {
            
        }

        private void GetFibonacci(FibonacciMessage message)
        {
            for (int i = 0; i < message.N_process; i++)
            {
                var numberIndex = message.StartIndex + i;
                var result = Fibonacci.IsSleepy(message.Fibonacci[numberIndex]);
                ProcessingData.ValideNumber(result);
            }
        }
    }
}
