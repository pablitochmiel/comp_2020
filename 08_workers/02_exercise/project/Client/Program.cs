using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using Greet;
using Grpc.Net.Client;
using Ram;

//using Wrap;

namespace Client
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static async Task Main()
        {
            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };


            using var channel = GrpcChannel.ForAddress("https://localhost:5001",
                new GrpcChannelOptions { HttpHandler = httpHandler });
            var client =  new Greeter.GreeterClient(channel);
            var request = new HelloRequest { Name = "GreeterClient" };
            var reply = await client.SayHelloAsync(request);
            Console.WriteLine("Greeting: " + reply.Message+"\n");
            
            var client2 =  new RamInfo.RamInfoClient(channel);
            var request2 = new RamRequest();
            var reply2 = await client2.GiveInformationAsync(request2);
            Console.WriteLine(reply2.Message);
        }
    }
}
