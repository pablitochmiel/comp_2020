using System;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Wrap;

//using Microsoft.Extensions.Logging;

namespace Server.Services
{
    public class WrapperService : Wrapper.WrapperBase
    {
        // private readonly ILogger<GreeterService> _logger;
        // public GreeterService(ILogger<GreeterService> logger)
        // {
        //     _logger = logger;
        // }

        public override Task<WrapReply> WrapText(WrapRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(request?.Text);
            }

            //string temp= request.Text.Split().Aggregate("", (current, words) => current + words + "\n");

            string temp = "";
            for (var i = 0; i < request.Text.Length; i += request.NCol)
            {
                if (i + request.NCol < request.Text.Length)
                {
                    temp += request.Text.Substring(i, request.NCol)+"\n";
                }
                else
                {
                    temp += request.Text.Substring(i)+"\n";
                }
            }
            
            return Task.FromResult(new WrapReply
            {
                Text = temp
            });
        }
    }
}