using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Service.Services;

namespace Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private int _i;
        private double _sum;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _i = 0;
            _sum = 0;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                
                var info = new ProcessStartInfo("free -m")
                    {FileName = "/bin/bash", Arguments = "-c \"free -m\"", RedirectStandardOutput = true};
                string output;
                using (var process = Process.Start(info))
                {
                    output = await process!.StandardOutput.ReadToEndAsync()!.ConfigureAwait(false);
                }

                var lines = output!.Split("\n");
                var memory=lines[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                _sum += ulong.Parse(memory[2], CultureInfo.CurrentCulture);
                ++_i;
                RamInfoService.FreeRamAvg = Convert.ToDouble(_sum / _i);
                RamInfoService.FreeRam = ulong.Parse(memory[2],CultureInfo.CurrentCulture);
                
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
            }
        }
    }
}
