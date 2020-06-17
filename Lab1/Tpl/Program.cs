using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lab1
{   
    class Program
    {
        const string INPUT_FILE = @"C:\Users\Vadim\Source\ADA\Lab1\minput.txt";
        const string OUTPUT_FILE = @"C:\Users\Vadim\Source\ADA\Lab1\moutput-tpl.txt";
        static void Main(string[] args)
        {
            var fibn = Fibonacci.ReadFile(INPUT_FILE);

            for (int i = 1; i <= 41; i *= 2)
            {
                var result = await FiboTasks(fibn,i,1);
                Fibonacci.WriteFile(OUTPUT_FILE, result);
            }

            Console.ReadKey();
        }

        private static async Task<long[]> FiboTasks(long fibn,int numberOfTasks, int type)
        {
            var tasks = new List<Task>(numberOfTasks);

            for (int i = 0; i < numberOfTasks; i++)
            {
                int taskIndex = i;
                var task = new Task(() => { type == 1 ? Fibonacci.IsSleep(fibn); : Fibonacci.IsBusy(fibn); };
            }

            tasks.Add(task);

            var watch = Stopwatch.StartNew();
            tasks.ForEach(x => x.Start());
                await Task.WhenAll(tasks);
            watch.Stop();

            Console.WriteLine($"Threads: {watch.ElapsedMilliseconds} milliseconds");

            return tasks.Count();
        }
    }
}
