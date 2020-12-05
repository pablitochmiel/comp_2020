using System;
using System.Threading.Tasks;
using Grpc.Core;
using Ram;

//using Microsoft.Extensions.Logging;

namespace Service.Services
{
    public class RamInfoService :RamInfo.RamInfoBase
    {
        // private readonly ILogger<GreeterService> _logger;
        // public GreeterService(ILogger<GreeterService> logger)
        // {
        //     _logger = logger;
        // }

        public static ulong FreeRam{ get; set; }
        public static double FreeRamAvg { get; set; }

        public override Task<RamReply> GiveInformation(RamRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return Task.FromResult(new RamReply
            {
                Message = $"free Ram: {FreeRam}, avg: {FreeRamAvg}"
            });
        }
    }
}