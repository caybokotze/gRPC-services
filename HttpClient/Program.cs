using System;
using System.Diagnostics;
using System.Net.Http;
using RestSharp;

namespace HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://localhost:5001/");
            
            var timer = new Stopwatch();
            timer.Start();

            for (var i = 0; i < 10_000; i++)
            {
                var request = new RestRequest("", Method.POST, DataFormat.Json);
                var payload = new JsonObject {{"name", "HttpClient"}};

                request.AddParameter("application/json", payload, ParameterType.RequestBody);
                
                var response = client.Execute(request);
                Console.WriteLine(response.Content);
            }
            
            timer.Stop();
            Console.WriteLine("Time elapsed: " + Math.Round(timer.Elapsed.TotalSeconds, 3) + " seconds");

            Console.WriteLine("Done");
        }
    }
}