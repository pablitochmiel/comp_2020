using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                try
                {
                    await Task.Delay(1000, stoppingToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    _logger.LogInformation("Operation Canceled at: {time}", DateTime.Now);
                    break;
                }
                // _logger.LogInformation("Worker running at:", DateTimeOffset.Now);
                // try
                // {
                //     await Task.Delay(1000, stoppingToken).ConfigureAwait(false);
                // }
                // catch (OperationCanceledException)
                // {
                //     _logger.LogInformation("Operation Canceled at:", DateTimeOffset.Now);
                //     break;
                // }
            }
        }
    }
}