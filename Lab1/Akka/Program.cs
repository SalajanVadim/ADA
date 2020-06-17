using System;
using System.Collections.Generic;

namespace Akka
{
    class Program
    {
        const string INPUT_FILE = @"C:\Users\Vadim\Source\ADA\Lab1\minput.txt";
        static void Main(string[] args)
        {
            var fibn = Fibonacci.ReadFile(INPUT_FILE);
            var n_actors = Int32.Parse(Console.ReadLine());
            ProcessFibonacci(fibn, n_actors);
        }

        private static void ProcessFibonacci(long[] fib_n, int n_actors)
        {
            var actorSystem = ActorSystem.Create($"Fibonacci-Actors-{n_actors}");
            var actors = new List<IActorRef>(n_actors);
            var messages = new List<FibonacciMessage>(n_actors);

            for (int i = 0; i < n_actors; i++)
            {
                int taskIndex = i;
                var actor = actorSystem.ActorOf(Props.Create<FibonacciActor>());

                int numbersPerTask = fib_n.Length / n_actors;
                int numbersToProcess = 0;

                if (taskIndex == n_actors - 1)
                    numbersToProcess = fib_n.Length - (numbersPerTask * (n_actors - 1));
                else
                    numbersToProcess = numbersPerTask;

                var message = new FibonacciMessage()
                {
                    Fibonacci = fib_n,
                    N_process = numbersToProcess,
                    StartIndex = taskIndex * numbersPerTask,
                };

                actors.Add(actor);
                messages.Add(message);
            }

            ProcessingData.Init(fib_n.Length);

            for (int i = 0; i < n_actors; i++)
                actors[i].Tell(messages[i]);
        }
    }
}
