using System;
using Microsoft.Extensions.Logging;
using Moq;
using Utils;
using Xunit;

namespace Test
{
    public class DemoTest
    {
        [Fact]
        public void Run()
        {
            // var mock = new Mock<TextWriter>();
            // Console.SetOut(mock.Object);
            var mock = new Mock<ILogger<Demo>>();
            
            const string name = "John";
            // mock.Setup(tw => tw.WriteLine($"Hello {name}!"));
            
            //var demo = new Demo(name);
            var demo = new Demo(mock.Object);
            
            demo.Run(name);
            
            mock.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(), 
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString() == $"Hello {name}!"),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)));
        
        }
    }
}