using System;
using System.Text;
using RabbitMQ.Client;

namespace MessageSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var conn = factory.CreateConnection())
            {
                using (var chann = conn.CreateModel())
                {
                    chann.QueueDeclare("hello", false, false, false);
                    Console.WriteLine("Type [exit] to exit or message to send");
                    var run = true;
                    while (run)
                    {
                        var line = Console.ReadLine();
                        if (line == "exit")
                        {
                            run = false;
                        }
                        else
                        {
                            var body = Encoding.UTF8.GetBytes(line);
                            chann.BasicPublish("", "hello", null, body);
                        }
                    }
                }
            }
        }
    }
}