using Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Receiver
{
    class Program
    {
        const string OUTPUT_FILE = @"C:\Users\Vadim\rep\ADA\Lab2\output.txt";

        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var i = 0;
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("Rabbit", false, false, false, null);
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, arg) => Message(arg,i++);
                channel.BasicConsume("Rabbit", true, consumer);
               
                Console.ReadKey();
            }
        }

        static void Message(BasicDeliverEventArgs basic, int i)
        {
                var n = Int64.Parse(Encoding.UTF8.GetString(basic.Body.ToArray()));
                Console.WriteLine("Receiver {0} C# {1}", i,n);
                var result = Fibonacci.IsSleepy(n);
                Fibonacci.Add(OUTPUT_FILE, result);
        }
    }
}
