using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using Greet;
using Grpc.Net.Client;
using Wrap;

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
            
            var client2 =  new Wrapper.WrapperClient(channel);
            var request2 = new WrapRequest {Text = "slowo slowo2 slowo3", NCol = 8};
            var reply2 = await client2.WrapTextAsync(request2);
            Console.WriteLine(reply2.Text);
        }
    }
}
