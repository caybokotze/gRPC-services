using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Timers;
using Grpc.Net.Client;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var timer = new Stopwatch();
            timer.Start();
            
            for (var i = 0; i < 10_000; i++)
            {
                var reply = await client.SayHelloAsync(
                    new HelloRequest { Name = "GreeterClient" });
                // Console.WriteLine("Greeting: " + reply.Message);
            }
            
            timer.Stop();
            Console.WriteLine("Time elapsed: " + Math.Round(timer.Elapsed.TotalSeconds, 3) + " seconds");
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}