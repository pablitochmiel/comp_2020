using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Service;
using Xunit;

namespace Test
{
    public class WorkerTest
    {
        [Fact]
        public async Task LoggerTest()
        {
            var mock = new Mock<ILogger<Worker>>();
            var worker = new Worker(mock.Object);
            await worker.StartAsync(CancellationToken.None);
            await Task.Delay(1000);
            await worker.StopAsync(CancellationToken.None);

            mock.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(), 
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Operation Canceled at:") || v.ToString().Contains("Worker running at:")),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)));
            
            
        }
    }
}