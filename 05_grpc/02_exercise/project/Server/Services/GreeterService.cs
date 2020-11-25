using System;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;
//using Microsoft.Extensions.Logging;

namespace Proto
{
    public class GreeterService : Greeter.GreeterBase
    {
        // private readonly ILogger<GreeterService> _logger;
        // public GreeterService(ILogger<GreeterService> logger)
        // {
        //     _logger = logger;
        // }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(request?.Name);
            }
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
