using Common;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        const string INPUT_FILE = @"C:\Users\Vadim\rep\ADA\Lab2\input.txt";
        const string OUTPUT_FILE = @"C:\Users\Vadim\rep\ADA\Lab2\output.txt";

        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Rabbit", false, false, false, null);

                var fibn = Fibonacci.ReadFile(INPUT_FILE);
                Fibonacci.Clear(OUTPUT_FILE);

                foreach (var item in fibn)
                {
                    var body = Encoding.UTF8.GetBytes(item.ToString());

                    channel.BasicPublish("", "Rabbit", null, body);
                    Console.WriteLine("Sent {0}", item);

                    Thread.Sleep(250);  
                }
            }
        }
    }
}
