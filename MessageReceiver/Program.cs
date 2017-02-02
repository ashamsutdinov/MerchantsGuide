using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory {HostName = "localhost"};
            using (var conn = factory.CreateConnection())
            {
                using (var chann = conn.CreateModel())
                {
                    chann.QueueDeclare("hello", false, false, false);
                    var consumer = new EventingBasicConsumer(chann);
                    consumer.Received += (sender, eventArgs) =>
                    {
                        var body = eventArgs.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("* Received: {0}", message);
                    };
                    chann.BasicConsume("hello", true, consumer);
                    Console.ReadKey();
                }
            }
        }
    }
}
