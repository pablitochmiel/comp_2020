using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main()
        {
            var httpHandler = new HttpClientHandler();

            httpHandler.ServerCertificateCustomValidationCallback = 
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            using var channel = GrpcChannel.ForAddress("https://localhost:5001",
                new GrpcChannelOptions { HttpHandler = httpHandler });
            var client =  new Greeter.GreeterClient(channel);
            var request = new HelloRequest { Name = "GreeterClient" };
            var reply = await client.SayHelloAsync(request);
            Console.WriteLine("Greeting: " + reply.Message);
        }
    }
}
